using System;
using System.Data.SqlClient;
using System.IO;
using AutoMapper;
using FluentAssertions;
using GeeksForLess_SampleStore.Repositories;
using GeeksForLess_SampleStore.ShoppingCart.Entities;
using GeeksForLess_SampleStore.ShoppingCart.ValuedObjects;
using GeeksForLess_SampleStore.ShoppingCartRepositories;
using GeeksForLess_SampleStore.Tests.AutomapperDtos;
using NHibernate;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class CustomerPersistanceSpecs : IDisposable
    {
        private IMapper _mapper;
        private ITransaction _transaction;
        private ISession _session;
        private CustomerRepository _customerRepository;
        private Product Bread;

        public CustomerPersistanceSpecs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, Product>();
            });

            _mapper = config.CreateMapper();

            Bread = _mapper.Map<Product>(new ProductDto { Id = 1, CategoryId = 1, Price = 50, Title = "Bread" });

            var connectionString = @"Server=(localdb)\GeeksForLess_SampleStore;Database=TestDB;Integrated Security=True";

            using (var sqlConnection = new SqlConnection(connectionString))
            using (var fileReader = new StreamReader("Script.PostDeployment.sql"))
            using (var sqlCommand = new SqlCommand(fileReader.ReadToEnd(), sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                finally
                {
                    if (sqlConnection.State != System.Data.ConnectionState.Closed)
                    {
                        sqlConnection.Close();
                    }
                }
            }

            //var dacpacService = new DacServices(connectionString);
            //dacpacService.Deploy(DacPackage.Load("TestDB.dacpac"), "TestDB");

            SessionFactory.Init(connectionString);
            _session = SessionFactory.OpenSession();
            _transaction = _session.BeginTransaction();
            _customerRepository = new CustomerRepository(_session);
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _session.Dispose();
        }

        [Fact]
        public void We_can_get_specific_customer_from_db()
        {

            var santa = _customerRepository.GetById(1);
            santa.Id.Should().Be(1);
            santa.VisitingCard.FirstName.Should().Be("Santa");
            santa.VisitingCard.LastName.Should().Be("Claus");
        }

        [Fact]
        public void We_can_store_new_customer_with_empty_cart_into_db()
        {
            var newCustomer = new Customer(new VisitingCard("Andrey", "Kunetskiy"));
            _customerRepository.Save(newCustomer);

            newCustomer.Id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Customer_can_be_persisted_with_items_in_cart()
        {
            var santa = _customerRepository.GetById(1);
            santa.Cart.AddToCart(Bread, 3);

            _customerRepository.Save(santa);
            _transaction.Commit();

            var santaAfterLoad = _customerRepository.GetById(1);
            santaAfterLoad.Cart.GetAllItems().Count.Should().Be(1);
            santaAfterLoad.Cart.TotalCount.Should().Be(3);
            santaAfterLoad.Cart.Total.Should().Be(3 * Bread.Price);
        }
    }
}
