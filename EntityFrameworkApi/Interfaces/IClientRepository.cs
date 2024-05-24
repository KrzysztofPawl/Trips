using EntityFrameworkApi.Models;

namespace EntityFrameworkApi.Interfaces;

public interface IClientRepository
{
    Task<Client?> GetClientByIdAsync(int id);
    Task<Client?> GetClientByPeselAsync(string pesel);
    Task AddClientAsync(Client client);
    Task RemoveClientAsync(Client client);
    Task RemoveClientByIdAsync(int id);
    Task SaveChangesAsync();
}