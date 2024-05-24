


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkApi.Models
{
    [Table("Client_Trip", Schema = "trip")]
    public class ClientTrip
    {
        [Key, Column(Order = 0)]
        public int IdClient { get; set; }
        
        [Key, Column(Order = 1)]
        public int IdTrip { get; set; }
        
        public DateTime RegisteredAt { get; set; }
        
        public DateTime? PaymentDate { get; set; }
        
        [ForeignKey("IdClient")]
        public Client Client { get; set; }
        
        [ForeignKey("IdTrip")]
        public Trip Trip { get; set; }
    }
}