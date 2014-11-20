namespace SampleDataGenerator.Tests
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public Guid Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Person> Relatives { get; set; }
    }
}