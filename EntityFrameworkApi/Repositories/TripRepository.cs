
using EntityFrameworkApi.Data;
using EntityFrameworkApi.Interfaces;
using EntityFrameworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApi.Repositories;

public class TripRepository : ITripRepository
{
    private readonly TripContext _context;

    public TripRepository(TripContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Trip>> GetAllTripsAsync()
    {
        return await _context.Trips
            .Include(t => t.ClientTrips).ThenInclude(ct => ct.Client)
            .Include(t => t.CountryTrips).ThenInclude(ct => ct.Country)
            .OrderByDescending(t => t.DateFrom)
            .ToListAsync();
    }

    public async Task<Trip?> GetTripByIdAsync(int id)
    {
        return await _context.Trips
            .Include(t => t.ClientTrips).ThenInclude(ct => ct.Client)
            .Include(t => t.CountryTrips).ThenInclude(ct => ct.Country)
            .FirstOrDefaultAsync(t => t.IdTrip == id);
    }

    public async Task AddClientTripAsync(ClientTrip clientTrip)
    {
        await _context.ClientTrips.AddAsync(clientTrip);
        await _context.SaveChangesAsync();
    }
}