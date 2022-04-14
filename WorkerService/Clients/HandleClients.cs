using DomainModels.Interfaces.Repositories;

namespace WorkerService.Clients;

internal sealed class HandleClients : ClientsUtils
{
    private readonly IClientsRepository _clientsRepository;

    public HandleClients
    (
       IClientsRepository clientsRepository
    )
    {
        _clientsRepository = clientsRepository;
    }

    public void Execute()
    {
        var minMenuValidOption = 1;
        var maxMenuValidOption = 6;
        var exitComand = 6;

        PrintLastFiveRegisters();

        var option = 0;
        while (option != exitComand)
        {
            PrintPrincipalMenu();

            option = EnterOption(minMenuValidOption, maxMenuValidOption);

            ExecuteSelectedAction(option);
        }
    }

    private static void PrintPrincipalMenu()
    {
        Console.WriteLine("*****Bem vindo ao gerenciador de alunos da AcademiaX*****");
        Console.WriteLine("1- Cadastrar novo aluno");
        Console.WriteLine("2- Listar todos os Alunos");
        Console.WriteLine("3- Procurar um aluno");
        Console.WriteLine("4- Deletar um aluno");
        Console.WriteLine("5- Atualizar um aluno");
        Console.WriteLine("6- Sair");
    }

    private int ExecuteSelectedAction(int option)
    {
        switch (option)
        {
            case 1:
                var createClient = new CreateClient(_clientsRepository);
                createClient.Execute();
                return 1;
            case 2:
                var printAllClients = new PrintAllClients(_clientsRepository);
                printAllClients.Execute();
                return 2;
            case 3:
                var findAndPrintOneClient = new PrintOneClient(_clientsRepository);
                findAndPrintOneClient.Execute();
                return 3;
            case 4:
                var findAndDeleteOneClient = new DeleteClient(_clientsRepository);
                findAndDeleteOneClient.Execute();
                return 4;
            case 5:
                var findAndUpdateOneClient = new UpdateClient(_clientsRepository);
                findAndUpdateOneClient.Execute();
                return 5;
            case 6:
                return 6;
            default:
                Console.WriteLine("Opção Inválida, tente novamente...");
                return 0;
        }
    }

    private void PrintLastFiveRegisters()
    {
        var clients = _clientsRepository.GetAll();
        clients.Reverse();

        Console.WriteLine("Últimos 5 clientes cadastrados: \n\r");

        if(clients.Count == 0)
        {
            Console.WriteLine("Ainda não há alunos cadastrados...");
            return;
        }

        foreach(var client in clients)
        {
            var index = clients.IndexOf(client);
            if(index < 5)
                Console.WriteLine($"{index + 1}-{client}");
        }
    }
}
