using System.IO;
using System.Reflection;
using GeeksForLess_SampleStore.Logic.Utils;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class ShoppingCartIntegrationSpecs
    {
        [Fact]
        public void We_can_remove_item_from_cart_after_the_cart_was_persisted()
        {
            System.Uri uri = new System.Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase));
            var connectionString = string.Format(@"Server=(localdb)\GeeksForLess_SampleStore;Integrated Security=true;AttachDbFileName={0}\TestDB.mdf;", Path.Combine(uri.LocalPath, "DB"));

            SessionFactory.Init(connectionString);
        }
    }
}
