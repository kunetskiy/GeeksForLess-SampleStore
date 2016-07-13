using System;
using System.Text;
using GeeksForLess_SampleStore.Logic.Common;

namespace GeeksForLess_SampleStore.Logic.ValuedObjects
{
    public sealed class Address : ValueObject<Address>
    {
        public string Country { get; }
        public string State { get; }
        public string ZipCode { get; }
        public string City { get; }
        public string AddressLine { get; }

        public string FullAddress =>
            Country + ", " +
            State + " " +
            ZipCode + ", " +
            City + ", " +
            AddressLine;

        public static Address Empty => new Address();

        private Address() { }

        public Address(string country, string state, string zipCode, string city, string addressLine) : this()
        {
            if (string.IsNullOrEmpty(country))
                throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrEmpty(state))
                throw new ArgumentNullException(nameof(state));
            if (string.IsNullOrEmpty(zipCode))
                throw new ArgumentNullException(nameof(zipCode));
            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException(nameof(city));
            if (string.IsNullOrEmpty(addressLine))
                throw new ArgumentNullException(nameof(addressLine));

            Country = country;
            State = state;
            ZipCode = zipCode;
            City = city;
            AddressLine = addressLine;
        }

        internal override bool EqualsCore(Address other)
        {
            return (Country == null && other.Country == null 
                        || ReferenceEquals(Country, other.Country) 
                        || Country.Equals(other.Country, StringComparison.InvariantCultureIgnoreCase))
                && (State == null && other.State == null
                        || ReferenceEquals(State, other.State)
                        || State.Equals(other.State, StringComparison.InvariantCultureIgnoreCase))
                && (ZipCode == null && other.ZipCode == null
                        || ReferenceEquals(ZipCode, other.ZipCode)
                        || ZipCode.Equals(other.ZipCode, StringComparison.InvariantCultureIgnoreCase))
                && (City == null && other.City == null
                        || ReferenceEquals(City, other.City)
                        || City.Equals(other.City, StringComparison.InvariantCultureIgnoreCase))
                && (AddressLine == null && other.AddressLine == null
                        || ReferenceEquals(AddressLine, other.AddressLine)
                        || AddressLine.Equals(other.AddressLine, StringComparison.InvariantCultureIgnoreCase));
        }

        internal override int GetHashCodeCore()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append(Country)
                .Append(State)
                .Append(ZipCode)
                .Append(City)
                .Append(AddressLine);

            return stringBuilder.ToString().GetHashCode();
        }
    }
}
