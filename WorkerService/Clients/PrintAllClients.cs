using DomainModels.Interfaces.Repositories;

namespace WorkerService.Clients;

internal sealed class PrintAllClients : ClientsUtils
{
    private readonly IClientsRepository _clientsRepository;

    public PrintAllClients
    (
        IClientsRepository clientsRepository
    )
    {
        _clientsRepository = clientsRepository;
    }

    public void Execute()
    {
        var clients = _clientsRepository.GetAll();

        if (clients.Count == 0)
        {
            Console.WriteLine("Não há clientes cadastrados...");
            return;
        }

        clients.ForEach(client => Console.WriteLine($"{client}"));
    }
}
