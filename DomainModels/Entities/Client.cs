namespace DomainModels.Entities;

public sealed class Client : Person
{
    public bool IsPremium { get; set; }

    public Client(Guid id, string firstName, string lastName, DateOnly birthDate, bool isPremium) : base(id, firstName, lastName, birthDate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        IsPremium = isPremium;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, " +
            $"{PrintPremiumStatus()} e " +
            $"faltam {DaysForBirthDay()} dias para o seu aniversário.";
    }

    private string PrintPremiumStatus()
    {
        if (IsPremium)
            return "Possui plano premium";

        return "Não possui plano premium";
    }
}
