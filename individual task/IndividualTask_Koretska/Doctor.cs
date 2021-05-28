using System;


public enum Specializations
{
    Therapist,
    Dentist,
    Pediatrician,
    Oculist,
    Surgeon
}
[Serializable]
public class Doctor : Person
{
    private int yearOfStartPractice;
    private Specializations specialization;

    public int YearOfStartPractice
    {
        get { return yearOfStartPractice; }
        set { yearOfStartPractice = value; }
    }

    public Specializations Specialization
    {
        get { return specialization; }
        set { specialization = value; }
    }

    public Doctor() : base()
    {
        yearOfStartPractice = 0;
        specialization = Specializations.Therapist;
    }

    public Doctor(int taxNumber, string firstName, string lastName, DateTime birthDate, int yearOfStartPractice, Specializations specialization) : base(taxNumber, firstName, lastName, birthDate)
    {
        this.yearOfStartPractice = yearOfStartPractice;
        this.specialization = specialization;
    }

    public override void Input()
    {
        base.Input();

        Console.Write("Enter the year of start practice: ");
        yearOfStartPractice = Int32.Parse(Console.ReadLine());

        if (yearOfStartPractice <= Birthdate.Year)
        {
            throw new Exception("The year of start practice cannot be less than year of birth.");
        }

        Console.WriteLine("Choose the specialization:");

        Console.WriteLine();

        Console.WriteLine("0 - Therapist");
        Console.WriteLine("1 - Dentist");
        Console.WriteLine("2 - Pediatrician");
        Console.WriteLine("3 - Oculist");
        Console.WriteLine("4 - Surgeon");

        Console.WriteLine();

        int specInput = Int32.Parse(Console.ReadLine());

        switch (specInput)
        {
            case 0:
                specialization = Specializations.Therapist;
                break;
            case 1:
                specialization = Specializations.Dentist;
                break;
            case 2:
                specialization = Specializations.Pediatrician;
                break;
            case 3:
                specialization = Specializations.Oculist;
                break;
            case 4:
                specialization = Specializations.Surgeon;
                break;
            default:
                throw new ArgumentException("Invalid specialization choice");
        }  
    }

    public override string ToString()
    {
        return $"{base.ToString()}Specialization: {Specialization}\nYear of start practice: {YearOfStartPractice}\n";
    }
}