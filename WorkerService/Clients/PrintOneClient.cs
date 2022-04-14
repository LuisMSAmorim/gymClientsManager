using DomainModels.Interfaces.Repositories;

namespace WorkerService.Clients;

internal sealed class PrintOneClient : ClientsUtils
{
    private readonly IClientsRepository _clientsRepository;

    public PrintOneClient
    (
        IClientsRepository clientsRepository
    )
    {
        _clientsRepository = clientsRepository;
    }

    public void Execute()
    {
        var selectClients = new SelectClient(_clientsRepository);

        var client = selectClients.Execute();

        Console.Write(client);
    }
}
