using EntityFrameworkApi.Models;

namespace EntityFrameworkApi.Interfaces;

public interface ITripRepository
{
    Task<IEnumerable<Trip>> GetAllTripsAsync();
    Task<Trip?> GetTripByIdAsync(int id);
    Task AddClientTripAsync(ClientTrip clientTrip);
}