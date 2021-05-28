using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();

        try
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the Doctor or Person information: ");

                Console.WriteLine();

                Console.WriteLine("0 - Person");
                Console.WriteLine("1 - Doctor");

                int typeInput = Int32.Parse(Console.ReadLine());
                Person entity;

                switch (typeInput)
                {
                    case 0:
                        entity = new Person();
                        break;
                    case 1:
                        entity = new Doctor();
                        break;
                    default:
                        throw new ArgumentException("Invalid type choice.");
                }

                persons.Add(entity);
                entity.Input();
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }

        IEnumerable<Person> therapistsInfo = from person in persons
                                             where person is Doctor && (person as Doctor).Specialization == Specializations.Therapist && person.GetAge() > 50
                                             select person;

        if (therapistsInfo.Count() > 0)
        {
            Console.WriteLine("Therapists of age 50+: ");
            Console.WriteLine();

            foreach (Doctor doc in therapistsInfo)
            {
                doc.Output();
            }
        }

        Console.WriteLine("Persons sorted by first and last name: ");
        Console.WriteLine();

        IEnumerable<Person> sortedPersonsInfo = persons.OrderBy(person => person.Firstname).ThenBy(person => person.Lastname);

        using (StreamWriter sw = new StreamWriter(@"C:\Users\user\source\repos\IndividualTask_Koretska\output.txt", false))
        {
            foreach (Person person in sortedPersonsInfo)
            {
                person.Output();
                sw.WriteLine(person);
            }
        }

        XmlSerializer formatter = new XmlSerializer(typeof(List<Person>), new Type[] { typeof(Doctor) });

        using (FileStream fs = new FileStream(@"C:\Users\user\source\repos\IndividualTask_Koretska\serialized.xml", FileMode.Create))
        {
            formatter.Serialize(fs, persons);
        }

        using (FileStream fs = new FileStream(@"C:\Users\user\source\repos\IndividualTask_Koretska\serialized.xml", FileMode.Open))
        {
            List<Person> newPersons = (List<Person>)formatter.Deserialize(fs);

            Console.WriteLine("Deserialized persons: ");
            Console.WriteLine();

            foreach (Person person in newPersons)
            {
                person.Output();
            }
        }
    }
}
