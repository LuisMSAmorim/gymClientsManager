using DomainModels.Entities;

namespace DomainModels.Interfaces.Repositories;

public interface IClientsRepository
{
    void Create(Client client);
    List<Client> GetAll();
    List<Client> GetByName(string name);
    void Update(Guid guid, Client client);
    void Delete(Guid guid);
}
