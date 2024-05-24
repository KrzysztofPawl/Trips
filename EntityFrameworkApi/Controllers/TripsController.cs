using Microsoft.AspNetCore.Mvc;
using EntityFrameworkApi.Exception;
using EntityFrameworkApi.Interfaces;
using EntityFrameworkApi.Models;
using EntityFrameworkApi.Models.DTO;

namespace EntityFrameworkApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Trip>>> GetTrips()
    {
        try
        {
            var trips = await _tripService.GetAllTripsAsync();
            return Ok(trips);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
        
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AddClientToTrip(int idTrip, [FromBody] ClientTripDto clientTripDto)
    {
        try
        {
            await _tripService.AddClientToTripAsync(idTrip, clientTripDto);
            return Ok();
        }
        catch (NoTripsFoundException e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
}