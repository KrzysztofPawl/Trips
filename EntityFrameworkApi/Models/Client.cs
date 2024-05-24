
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkApi.Models
{

    [Table("Client", Schema = "trip")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }
        
        [MaxLength(120)]
        public string FirstName { get; set; }
        
        [MaxLength(120)]
        public string LastName { get; set; }
        
        [MaxLength(120)]
        public string Email { get; set; }
        
        [MaxLength(120)]
        public string Telephone { get; set; }
        
        [MaxLength(120)]
        public string PESEL { get; set; }

        public List<ClientTrip> ClientTrips { get; set; } = new List<ClientTrip>();
    }
}