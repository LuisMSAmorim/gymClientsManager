using DomainModels.Entities;
using DomainModels.Interfaces.Repositories;

namespace WorkerService.Clients;

internal class SelectClient : ClientsUtils
{
    private readonly IClientsRepository _clientsRepository;

    public SelectClient
    (
        IClientsRepository clientsRepository
    )
    {
        _clientsRepository = clientsRepository;
    }

    public Client? Execute()
    {
        var nameToFind = EnterName("Digite o nome (ou parte) do cliente que você deseja exibir: ");

        var clientsList = FindClientsWithNameOrSubstring(nameToFind);

        if (clientsList.Count == 0)
        {
            Console.WriteLine("Não há resultados válidos para esta busca...");
            return null;
        }

        PrintFindedClientsMenu(clientsList);

        var selectedClient = SelectClientAtMenu(clientsList);

       return selectedClient;
    }

    private List<Client> FindClientsWithNameOrSubstring(string substring)
    {
        var clients = _clientsRepository.GetAll();

        return clients
            .Where(client => client.FirstName
            .ToLower()
            .Contains(substring.ToLower()))
            .ToList();
    }

    private static void PrintFindedClientsMenu(List<Client> clients)
    {
        Console.WriteLine("Selecione o cliente desejado: ");

        for (var index = 0; index < clients.Count; index++)
        {
            var firstName = clients[index].FirstName;
            var lastName = clients[index].LastName;

            Console.WriteLine($"{index}- {firstName} {lastName}");
        }
    }

    private static Client SelectClientAtMenu(List<Client> clients)
    {
        var minIndex = 0;
        var maxIndex = clients.Count - 1;

        var clientMenuOption = EnterOption(minIndex, maxIndex);

        var selectedClient = clients[clientMenuOption];

        return selectedClient;
    }
}
