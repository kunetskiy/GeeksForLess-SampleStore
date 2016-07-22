using System;
using System.Linq;
using FluentAssertions;
using GeeksForLess_SampleStore.Logic.RepositoryInterfaces;
using GeeksForLess_SampleStore.Repositories;
using Microsoft.SqlServer.Dac;
using NHibernate;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class ProductSpecs : IDisposable
    {
        public ProductSpecs()
        {
            var connectionString = @"Server=(localdb)\GeeksForLess_SampleStore;Database=TestDB;Integrated Security=True";
            var dacpacService = new DacServices(connectionString);
            dacpacService.Deploy(DacPackage.Load("TestDB.dacpac"), "TestDB");

            SessionFactory.Init(connectionString);
        }

        public void Dispose()
        {
            //Here we can revert DB changes or something else, if we need it :)
        }

        [Fact]
        public void We_can_get_all_products_from_storage()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                IProductRepository productRepository = new ProductRepository(session);
                var allProducts = productRepository.GetAll();

                allProducts.Count().Should().Be(4);
            }
        }
    }
}
