namespace EntityFrameworkApi.Interfaces;

public interface IClientService
{
    Task DeleteClientAsync(int idClient);
}