using System;
using System.Collections.Generic;

namespace SampleDataGenerator.Tests
{
    public class TestObject
    {
        public Guid GuidProperty { get; set; }

        public DateTime DateTimeProperty { get; set; }

        public string StringProperty1 { get; set; }

        public string StringProperty2 { get; set; }

        public string StringProperty3 { get; set; }

        public string StringProperty4 { get; set; }

        public IEnumerable<TestObject> NestedList { get; set; }

        public Guid? NullableGuidProperty { get; set; }

        public DateTime? NullableDateTimeProperty { get; set; }
    }
}