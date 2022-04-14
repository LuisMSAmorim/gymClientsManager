namespace DomainModels.Entities;

public abstract class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }

    public Person(Guid id, string firstName, string lastName, DateOnly birthDate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public int DaysForBirthDay()
    {
        var actualDay = DateTime.Now.DayOfYear;
        var birthDay = BirthDate.DayOfYear;

        if (AlreadyHadBirthdayThisYear())
            birthDay = BirthDate.AddYears(1).DayOfYear;

        return birthDay - actualDay;
    }

    private bool AlreadyHadBirthdayThisYear()
    {
        var actualDate = DateTime.Now;
        var birthDate = DateTime.Parse(BirthDate.ToString());

        var comparation = actualDate.CompareTo(birthDate);

        if (comparation < 0)
            return false;

        return true;
    }
}
