using EntityFrameworkApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        try
        {
            await _clientService.DeleteClientAsync(idClient);
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
            return NotFound(e.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
}