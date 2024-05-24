namespace EntityFrameworkApi.Models.DTO;

public class ClientTripDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PESEL { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public DateTime? PaymentDate { get; set; }
}