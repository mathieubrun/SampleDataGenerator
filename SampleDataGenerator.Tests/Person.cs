using System;
using System.Collections.Generic;

namespace SampleDataGenerator.Tests
{
    public class Person
    {
        public Guid Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Person> Relatives { get; set; }
    }
}