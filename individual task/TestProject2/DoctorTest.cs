using System;
using Xunit;
using System.IO;

namespace IndividualTaskTests
{
    public class DoctorTests
    {
        [Fact]
        public void OutputPrintsDoctorInformation()
        {
            StringWriter output = new StringWriter();
            // setting our own StreamWriter to be able to get all console output
            Console.SetOut(output);

            Doctor doctor = new Doctor(1278903, "Ivan", "Ivanenko", new DateTime(1965, 8, 7), 1987, Specializations.Therapist);

            doctor.Output();

            // output.ToString() gives everything that was printed to the console
            Assert.Equal("Ivan Ivanenko was born 07-08-1965\nTax number: 1278903\nSpecialization: Therapist\nYear of start practice: 1987\n\r\n", output.ToString());
        }

        [Fact]
        public void CreatingNewDoctorObject()
        {
            Doctor person = new Doctor(123456, "Ivanka", "Petrenko", new DateTime(1990, 04, 05), 2015, Specializations.Oculist);

            Assert.Equal(123456, person.TaxNumber);
            Assert.Equal("Ivanka", person.Firstname);
            Assert.Equal("Petrenko", person.Lastname);
            Assert.Equal(new DateTime(1990, 04, 05), person.Birthdate);
            Assert.Equal(2015, person.YearOfStartPractice);
            Assert.Equal(Specializations.Oculist, person.Specialization);
        }

        [Fact]
        public void CreatingNewDoctorObjectWithDefaultValues()
        {
            Doctor person = new Doctor();

            Assert.Equal(0, person.TaxNumber);
            Assert.Equal("Unknown", person.Firstname);
            Assert.Equal("Unknown", person.Lastname);
            Assert.Equal(new DateTime(2000, 01, 01), person.Birthdate);
            Assert.Equal(0, person.YearOfStartPractice);
            Assert.Equal(Specializations.Therapist, person.Specialization);
        }
    }
}
