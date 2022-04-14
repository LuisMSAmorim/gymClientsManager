using DomainModels.Entities;
using DomainModels.Interfaces.Repositories;

namespace Infrastructure.Repositories.InDisk;

public sealed class ClientsRepositoryInDisk : IClientsRepository
{
    private static readonly string dirPath = $"{Directory.GetCurrentDirectory()}\\clients.txt";

    public ClientsRepositoryInDisk()
    {
        CreateArchiveIfDoesntExists();
    }

    public void Create(Client client)
    {
        string[] clientsInDisk = File.ReadAllLines(dirPath);

        var newClient = FormatClient(client);

        List<string> clients = new();

        foreach(var line in clientsInDisk)
        {
            clients.Add(line);
        }

        clients.Add(newClient);

        File.WriteAllLines(dirPath, clients);
    }

    public void Delete(Guid guid)
    {
        string[] clientsInDisk = File.ReadAllLines(dirPath);

        List<string> clients = new();

        foreach (var line in clientsInDisk)
        {
            var client = GetClient(line);
            var formatedClient = FormatClient(client);
            var clientId = client.Id;

            if (clientId != guid)
                clients.Add(formatedClient);
        }

        File.Delete(dirPath);

        File.WriteAllLines(dirPath, clients);
    }

    public List<Client> GetAll()
    {
        string[] clientsInDisk = File.ReadAllLines(dirPath);

        List<Client> clients = new();

        foreach (var line in clientsInDisk)
        {
            var client = GetClient(line);

            clients.Add(client);
        }

        return clients;
    }

    public List<Client> GetByName(string name)
    {
        string[] clientsInDisk = File.ReadAllLines(dirPath);

        List<Client> clients = new();

        foreach (var line in clientsInDisk)
        {
            var client = GetClient(line);

            clients.Add(client);
        }

        return clients
            .Where(client => client.FirstName
            .ToLower()
            .Contains(name.ToLower()))
            .ToList();
    }

    public void Update(Guid guid, Client updatedClient)
    {
        string[] clientsInDisk = File.ReadAllLines(dirPath);

        List<string> clients = new();

        foreach (var line in clientsInDisk)
        {
            var client = GetClient(line);
            var formatedClient = FormatClient(client);
            var clientId = client.Id;

            if (clientId != guid)
            {
                clients.Add(formatedClient);
            }
            else
            {
                var formatedUpdatedClient = FormatClient(updatedClient);
                clients.Add(formatedUpdatedClient);
            }
        }

        File.Delete(dirPath);

        File.WriteAllLines(dirPath, clients);
    }

    private static Client GetClient(string line)
    {
        var clientString = line.Split(";");

        var clientId = Guid.Parse(clientString[0]);
        var clientFirstName = clientString[1];
        var clientLastName = clientString[2];
        var clientBirthDate = DateOnly.Parse(clientString[3]);
        var clientIsPremium = bool.Parse(clientString[4]);

        return new Client(clientId, clientFirstName, clientLastName, clientBirthDate, clientIsPremium);
    }

    private static string FormatClient(Client client)
    {
        return $"{client.Id};{client.FirstName};{client.LastName};{client.BirthDate};{client.IsPremium};";
    }

    private static void CreateArchiveIfDoesntExists()
    {
        if (!File.Exists(dirPath))
            File.Create(dirPath).Close();
    }
}
