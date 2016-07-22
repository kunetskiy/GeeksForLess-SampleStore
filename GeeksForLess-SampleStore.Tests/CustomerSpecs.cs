using GeeksForLess_SampleStore.Logic.Entities;
using GeeksForLess_SampleStore.Logic.RepositoryInterfaces;
using GeeksForLess_SampleStore.Logic.ValuedObjects;
using GeeksForLess_SampleStore.Repositories;
using NHibernate;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class CustomerSpecs
    {
        public CustomerSpecs()
        {
            var connectionString = @"Server=(localdb)\GeeksForLess_SampleStore;Database=TestDB;Integrated Security=True";

            SessionFactory.Init(connectionString);
        }

        [Fact]
        public void Customer_can_put_item_to_cart_and_persist_it()
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                IProductRepository productRepository = new ProductRepository(session);
                var allProducts = productRepository.GetAll();

                ICustomerRepository customerRepository = new CustomerRepository(session);
                var santaCustomer = new Customer(new VisitingCard("Andrey", "Kunetskiy"));

                //santaCustomer.Should().NotBe(null);
                //santaCustomer.Cart = null;
                //santaCustomer.Cart.Customer = santaCustomer;
                customerRepository.Save(santaCustomer);
                transaction.Commit();
            }

            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                ICustomerRepository customerRepository = new CustomerRepository(session);
                var santaCustomer = customerRepository.GetById(10);

                santaCustomer.Cart.AddToCart(Product.Bread, 1);
                santaCustomer.Cart.AddToCart(Product.TShirt, 1);

                customerRepository.Save(santaCustomer);
                transaction.Commit();
            }
        }
    }
}
