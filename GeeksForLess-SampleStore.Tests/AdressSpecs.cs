using System;
using FluentAssertions;
using GeeksForLess_SampleStore.Core.ValuedObjects;
using Xunit;

namespace GeeksForLess_SampleStore.Tests
{
    public class AdressSpecs
    {
        [Fact]
        public void Two_address_instances_equal_if_contain_same_parts()
        {
            Address addr1 = new Address("Ukraine", "Mykolayv", "54003", "Mykolayv", "Kolodyaznaya 13");
            Address addr2 = new Address("Ukraine", "Mykolayv", "54003", "Mykolayv", "Kolodyaznaya 13");

            addr1.Should().Be(addr2);
            addr1.FullAddress.Should().Be(addr2.FullAddress);
        }

        [Fact]
        public void Two_address_instances_do_not_equal_if_contain_different_parts()
        {
            Address addr1 = new Address("Ukraine", "Mykolayv", "54003", "Mykolayv", "Kolodyaznaya 13");
            Address addr2 = new Address("Ukraine", "Mykolayv", "54003", "Mykolayv", "Kolodyaznaya 12");

            addr1.Should().NotBe(addr2);
            addr1.GetHashCode().Should().NotBe(addr2.GetHashCode());
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("Ukraine", null, null, null, null)]
        [InlineData("Ukraine", "Mykolayv", null, null, null)]
        [InlineData("Ukraine", "Mykolayv", "54003", null, null)]
        [InlineData("Ukraine", "Mykolayv", "54003", "Mykolayv", null)]
        public void Invalid_address_can_not_be_constructed(string country, string state, string zip, string city, string addressLine)
        {
            Exception ex = Record.Exception(() => { Address addr = new Address(country, state, zip, city, addressLine); });
            ex.Should().BeOfType(typeof(ArgumentNullException));
        }
    }
}
