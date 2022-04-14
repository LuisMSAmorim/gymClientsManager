using DomainModels.Entities;
using DomainModels.Interfaces.Repositories;

namespace WorkerService.Clients;

internal sealed class CreateClient : ClientsUtils
{
    private readonly IClientsRepository _clientsRepository;

    public CreateClient
    (
        IClientsRepository clientsRepository
    )
    {
        _clientsRepository = clientsRepository;
    }

    public void Execute()
    {
        var clientId = Guid.NewGuid();
        var firstName = EnterName("Digite o primeiro nome do aluno: ");
        var lastName = EnterName("Digite o sobrenome do aluno: ");
        var birthDate = EnterBirthDate();
        var isPremium = SelectPremiumStatus();

        var client = new Client(clientId, firstName, lastName, birthDate, isPremium);

        _clientsRepository.Create(client);
    }
}
