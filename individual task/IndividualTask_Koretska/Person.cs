using System;
using System.Xml.Serialization;

[Serializable]
public class Person
{
    // Fields
    private int taxNumber;
    private string firstName;
    private string lastName;
    private DateTime birthDate;

    //Properties
    public int TaxNumber
    {
        get { return taxNumber; }
        set { taxNumber = value; }
    }

    public string Firstname
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string Lastname
    {
        get { return lastName; }
        set { lastName = value; }
    }

    [XmlElement(DataType = "date")]
    public DateTime Birthdate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    // Constructors
    public Person()
    {
        taxNumber = 0;
        firstName = "Unknown";
        lastName = "Unknown";
        birthDate = new DateTime(2000, 01, 01);
    }

    public Person(int taxNumber, string firstName, string lastName, DateTime birthDate)
    {
        this.taxNumber = taxNumber;
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} was born {birthDate.ToString("dd/MM/yyyy")}\nTax number: {taxNumber}\n";
    }

    public virtual void Input()
    {
        Console.Write("Enter the first name: ");
        firstName = Console.ReadLine();

        Console.Write("Enter the last name: ");
        lastName = Console.ReadLine();

        Console.Write("Enter tax number: ");
        taxNumber = Int32.Parse(Console.ReadLine());

        Console.Write($"Enter the date of birth (DD/MM/YYYY): ");
        birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
    }

    public virtual void Output()
    {
        Console.WriteLine(this);
    }

    public int GetAge()
    {
        DateTime today = DateTime.Today;

        int age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age)) age--;

        return age;
    }
}