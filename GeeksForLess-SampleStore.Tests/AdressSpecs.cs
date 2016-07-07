using FluentAssertions;
using GeeksForLess_SampleStore.Logic.SharedKernel;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class AdressSpecs
    {
        [Fact]
        public void Two_address_instances_equal_if_contain_same_address_parts()
        {
            Address addr1 = new Address("Ukraine", "Mykolayv", "54003", "Mykolayv", "Kolodyaznaya 13");
            Address addr2 = new Address("Ukraine", "Mykolayv", "54003", "Mykolayv", "Kolodyaznaya 13");

            addr1.Should().Be(addr2);
            addr1.FullAddress.Should().Be(addr2.FullAddress);
        }

        [Fact]
        public void Two_address_instances_do_not_equal_if_contain_different_address_parts()
        {
            Address addr1 = new Address("Ukraine", "Mykolayv", "54003", "Mykolayv", "Kolodyaznaya 13");
            Address addr2 = new Address("Ukraine", "Mykolayv", "54003", "Mykolayv", "Kolodyaznaya 12");

            addr1.Should().NotBe(addr2);
            addr1.GetHashCode().Should().NotBe(addr2.GetHashCode());
        }
    }
}
