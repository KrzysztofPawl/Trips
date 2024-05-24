using EntityFrameworkApi.Models;
using EntityFrameworkApi.Models.DTO;

namespace EntityFrameworkApi.Interfaces;

public interface ITripService
{
    Task<List<TripDto>> GetAllTripsAsync();
    Task<Trip> GetTripByIdAsync(int id);
    Task AddClientToTripAsync(int idTrip, ClientTripDto clientTripDto);
}