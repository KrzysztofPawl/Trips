using EntityFrameworkApi.Exception;
using EntityFrameworkApi.Interfaces;
using EntityFrameworkApi.Models;
using EntityFrameworkApi.Models.DTO;

namespace EntityFrameworkApi.Service;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;
    private readonly IClientRepository _clientRepository;

    public TripService(ITripRepository tripRepository, IClientRepository clientRepository)
    {
        _tripRepository = tripRepository;
        _clientRepository = clientRepository;
    }
    
    public async Task<List<TripDto>> GetAllTripsAsync()
    {
        var result = await _tripRepository.GetAllTripsAsync();
        if (result == null)
        {
            throw new NoTripsFoundException("Trip not found!");
        }

        var tripDtos = result.Select(trip => new TripDto
        {
            Name = trip.Name,
            Description = trip.Description,
            DateFrom = trip.DateFrom,
            DateTo = trip.DateTo,
            MaxPeople = trip.MaxPeople,
            Countries = trip.CountryTrips.Select(ct => new CountryDto
            {
                Name = ct.Country.Name
            }).ToList(),
            Clients = trip.ClientTrips.Select(ct => new ClientDto
            {
                FirstName = ct.Client.FirstName,
                LastName = ct.Client.LastName
            }).ToList()
        }).ToList();
        
        return tripDtos;
    }

    public async Task<Trip> GetTripByIdAsync(int id)
    {
        var result = await _tripRepository.GetTripByIdAsync(id);
        if (result == null)
        {
            throw new NoTripsFoundException("Trip not found!");
        }

        return result;
    }

    public async Task AddClientToTripAsync(int idTrip, ClientTripDto clientTripDto)
    {
        var trip = await _tripRepository.GetTripByIdAsync(idTrip);
        if (trip == null)
        {
            throw new NoTripsFoundException("Trip not found!");
        }

        var client = await _clientRepository.GetClientByPeselAsync(clientTripDto.PESEL);
        if (client == null)
        {
            client = new Client
            {
                FirstName = clientTripDto.FirstName,
                LastName = clientTripDto.LastName,
                PESEL = clientTripDto.PESEL,
                Email = clientTripDto.Email,
                Telephone = clientTripDto.Telephone,
                
            };
            await _clientRepository.AddClientAsync(client);
            Console.WriteLine($"New client ID: {client.IdClient}"); // Dodaj log, aby sprawdzić ID klienta
        }
        else if (client.ClientTrips.Any(ct => ct.IdTrip == idTrip))
        {
            throw new InvalidOperationException("client is already assigned to this trip");
        }

        var clientTrip = new ClientTrip
        {
            IdClient = client.IdClient,
            IdTrip = idTrip,
            PaymentDate = clientTripDto.PaymentDate,
            RegisteredAt = DateTime.Now
        };
        await _tripRepository.AddClientTripAsync(clientTrip);
        
    }
}