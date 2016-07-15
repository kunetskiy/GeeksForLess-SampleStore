using System;
using System.Linq;
using FluentAssertions;
using GeeksForLess_SampleStore.Logic.RepositoryInterfaces;
using GeeksForLess_SampleStore.Repositories;
using NHibernate;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class ProductSpecs : IDisposable
    {
        public ProductSpecs()
        {
            var connectionString = @"Server=(localdb)\GeeksForLess_SampleStore;Database=TestDB;Integrated Security=True";

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
