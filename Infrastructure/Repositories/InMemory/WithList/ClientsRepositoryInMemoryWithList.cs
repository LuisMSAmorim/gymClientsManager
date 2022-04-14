using DomainModels.Entities;
using DomainModels.Interfaces.Repositories;

namespace Infrastructure.Repositories.InMemory;

public sealed class ClientsRepositoryInMemoryWithList : IClientsRepository
{
    private static readonly List<Client> ClientsRepository = new();

    public void Create(Client client)
    {
        ClientsRepository.Add(client);
    }

    public void Delete(Guid guid)
    {
        var client = ClientsRepository
            .Where(client => client.Id == guid)
            .Single();

        ClientsRepository.Remove(client);
    }

    public List<Client> GetAll()
    {
        return ClientsRepository;
    }

    public List<Client> GetByName(string name)
    {
        return ClientsRepository
            .Where(client => client.FirstName
            .ToLower()
            .Contains(name.ToLower()))
            .ToList();
    }

    public void Update(Guid guid, Client clientUpdate)
    {
        var client = ClientsRepository
            .Where(client => client.Id == guid)
            .Single();

        var clientIndex = ClientsRepository.IndexOf(client);

        ClientsRepository[clientIndex] = clientUpdate;
    }
}
