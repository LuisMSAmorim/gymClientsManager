using DomainModels.Entities;
using DomainModels.Interfaces.Repositories;

namespace WorkerService.Clients;

internal sealed class UpdateClient : ClientsUtils
{
    private readonly IClientsRepository _clientsRepository;

    public UpdateClient
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

        if (client != null)
        {
            var updateClientData = InsertUpdateData(client.Id);

            _clientsRepository.Update(client.Id, updateClientData);
            Console.WriteLine("Client atualizado...");
        }
    }

    private static Client InsertUpdateData(Guid clientId)
    {
        var firstName = EnterName("Digite o primeiro nome do aluno: ");
        var lastName = EnterName("Digite o sobrenome do aluno: ");
        var birthDate = EnterBirthDate();
        var isPremium = SelectPremiumStatus();

        return new Client(clientId, firstName, lastName, birthDate, isPremium);
    }
}
