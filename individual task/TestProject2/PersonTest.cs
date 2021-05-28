using System;
using Xunit;
using System.IO;

namespace IndividualTaskTests
{
    public class PersonTest
    {
        [Fact]
        public void GetAgeReturnsPersonFullAge()
        {
            Person person = new Person();

            person.Birthdate = new DateTime(2000, 11, 11);

            Assert.Equal(20, person.GetAge());
        }

        [Fact]
        public void OutputPrintsPersonInformation()
        {
            StringWriter output = new StringWriter();
            // setting our own StreamWriter to be able to get all console output
            Console.SetOut(output); 

            Person person = new Person(1278903, "Ivan", "Ivanenko", new DateTime(1965, 8, 7));

            person.Output();

            // output.ToString() gives everything that was printed to the console
            Assert.Equal("Ivan Ivanenko was born 07-08-1965\nTax number: 1278903\n\r\n", output.ToString());
        }

        [Fact]
        public void CreatingNewObject()
        {
            Person person = new Person(123456, "Ivanka", "Petrenko", new DateTime(1990, 04, 05));

            Assert.Equal(123456, person.TaxNumber);
            Assert.Equal("Ivanka", person.Firstname);
            Assert.Equal("Petrenko", person.Lastname);
            Assert.Equal(new DateTime(1990, 04, 05), person.Birthdate);
        }

        [Fact]
        public void CreatingNewObjectWithDefaultValues()
        {
            Person person = new Person();

            Assert.Equal(0, person.TaxNumber);
            Assert.Equal("Unknown", person.Firstname);
            Assert.Equal("Unknown", person.Lastname);
            Assert.Equal(new DateTime(2000, 01, 01), person.Birthdate);
        }

        [Fact]
        public void GetAgeReturnsPersonAge()
        {
            Person person = new Person();

            person.Birthdate = new DateTime(2000, 01, 01);

            Assert.Equal(21, person.GetAge());
        }
    }
}
