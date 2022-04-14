using DomainModels.Interfaces.Repositories;

namespace WorkerService.Clients;

internal sealed class DeleteClient : ClientsUtils
{
    private readonly IClientsRepository _clientsRepository;

    public DeleteClient
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

        if(client != null)
        {
            _clientsRepository.Delete(client.Id);
            Console.WriteLine("Cliente deletado...");
        }
    }
}
