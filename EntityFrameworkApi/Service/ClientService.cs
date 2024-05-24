using EntityFrameworkApi.Exception;
using EntityFrameworkApi.Interfaces;

namespace EntityFrameworkApi.Service;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task DeleteClientAsync(int idClient)
    {
        var client = await _clientRepository.GetClientByIdAsync(idClient);
        if (client == null)
        {
            throw new NoClientFoundException("No client found!");
        }

        if (client.ClientTrips.Any())
        {
            throw new InvalidOperationException("Client has assigned trips!");
        }

        await _clientRepository.RemoveClientAsync(client);
        await _clientRepository.SaveChangesAsync();
    }
}