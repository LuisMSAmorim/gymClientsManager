using DomainModels.Interfaces.Repositories;
using System.Globalization;
using WorkerService.Clients;

namespace WorkerService;

public sealed class Worker : BackgroundService
{
    private readonly IClientsRepository _clientsRepository;

    public Worker
    (
        IClientsRepository clientsRepository
    )
    {
        _clientsRepository = clientsRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        Execute();
    }

    private void Execute()
    {
        var handleClients = new HandleClients(_clientsRepository);
        handleClients.Execute();
    }
}
