

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkApi.Models
{
    [Table("Trip", Schema = "trip")]
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTrip { get; set; }
        
        [MaxLength(220)]
        public string Name { get; set; }
        
        [MaxLength(220)]
        public string Description { get; set; }
        
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }

        public List<ClientTrip> ClientTrips { get; set; } = new List<ClientTrip>();
        public List<CountryTrip> CountryTrips { get; set; } = new List<CountryTrip>();
    }
}