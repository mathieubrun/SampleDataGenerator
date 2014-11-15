namespace SampleDataGenerator.Tests
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        public Guid Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}