using EntityFrameworkApi.Data;
using EntityFrameworkApi.Interfaces;
using EntityFrameworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApi.Repositories;

public class ClientRepository(TripContext context) : IClientRepository
{
    public async Task<Client?> GetClientByIdAsync(int id)
    {
        return await context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefaultAsync(c => c.IdClient == id);
    }

    public async Task<Client?> GetClientByPeselAsync(string pesel)
    {
        return await context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefaultAsync(c => c.PESEL == pesel);
    }

    public async Task AddClientAsync(Client client)
    {
        await context.Clients.AddAsync(client);
        await context.SaveChangesAsync();
        Console.WriteLine($"Client saved with ID: {client.IdClient}");
    }

    public async Task RemoveClientAsync(Client client)
    {
         context.Clients.Remove(client);
         await context.SaveChangesAsync();
    }

    public async Task RemoveClientByIdAsync(int id)
    {
        var client = await context.Clients.FirstOrDefaultAsync(c => c.IdClient == id);
        if (client != null)
        {
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
        }
        
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}