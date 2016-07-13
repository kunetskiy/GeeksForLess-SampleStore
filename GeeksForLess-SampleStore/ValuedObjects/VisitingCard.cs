using System;
using System.Text;
using GeeksForLess_SampleStore.Logic.Common;

namespace GeeksForLess_SampleStore.Logic.ValuedObjects
{
    public sealed class VisitingCard : ValueObject<VisitingCard>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => $"{LastName} {FirstName}";

        private VisitingCard()
        { }

        public VisitingCard(string firstName, string lastName) : this()
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        internal override bool EqualsCore(VisitingCard other)
        {
            return (FirstName == null && other.FirstName == null
                       || ReferenceEquals(FirstName, other.FirstName)
                       || FirstName.Equals(other.FirstName, StringComparison.InvariantCultureIgnoreCase))
               && (LastName == null && other.LastName == null
                       || ReferenceEquals(LastName, other.LastName)
                       || LastName.Equals(other.LastName, StringComparison.InvariantCultureIgnoreCase));
        }

        internal override int GetHashCodeCore()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append(FirstName)
                .Append(LastName);

            return stringBuilder.ToString().GetHashCode();
        }
    }
}
