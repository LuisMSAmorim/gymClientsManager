namespace WorkerService.Clients;

internal abstract class ClientsUtils
{
    protected static bool SelectPremiumStatus()
    {
        PrintPremiumMenu();
        var option = EnterOption(1, 2);

        return option == 1 ? true : false;
    }

    protected static void PrintPremiumMenu()
    {
        Console.WriteLine("Deseja adicionar assinatura premium ao cliente? ");
        Console.WriteLine("1- Sim");
        Console.WriteLine("2- Não");
    }

    protected static int EnterOption(int minNumber, int maxNumber)
    {
        while (true)
        {
            var option = EnterInteger();

            if (OptionIsValid(option, minNumber, maxNumber))
                return option;

            Console.WriteLine("Opção inválida, tente novamente...");
        }
    }

    protected static int EnterInteger()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int option))
                return option;

            Console.WriteLine("Opção inválida, tente novamente...");
        }
    }

    protected static string EnterName(string description)
    {
        Console.WriteLine(description);

        while (true)
        {
            var name = Console.ReadLine();

            if (NameIsValid(name!))
                return name!;

            Console.WriteLine("Entrada inválida, tente novamente...");
        }
    }

    protected static DateOnly EnterBirthDate()
    {
        Console.WriteLine("Digite a data de nascimento do aluno (dia/mês/ano): ");

        while (true)
        {
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly clientBirthDate))
                return clientBirthDate;

            Console.WriteLine("Data inválida, tente novamente...");
        }
    }

    protected static bool OptionIsValid(int option, int minNumber, int maxNumer)
    {
        if (option <= maxNumer && option >= minNumber)
            return true;

        return false;
    }

    protected static bool NameIsValid(string name)
    {
        if (name.Length < 2)
            return false;
        if (int.TryParse(name, out _))
            return false;

        return true;
    }
}
