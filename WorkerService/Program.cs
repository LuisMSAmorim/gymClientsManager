using DomainModels.Interfaces.Repositories;
using Infrastructure.Repositories.InDisk;
using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IClientsRepository, ClientsRepositoryInDisk>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
