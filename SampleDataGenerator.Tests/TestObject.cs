using System;
using System.Collections.Generic;

namespace SampleDataGenerator.Tests
{
    public class Person
    {
        public Guid Identifier { get; set; }

        public Guid? ForeignKeyIdentifier { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? WeddingDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Bio { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public IEnumerable<Person> Colleagues { get; set; }
    }
}