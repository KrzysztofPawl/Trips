


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkApi.Models
{
    [Table("Country", Schema = "trip")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCountry { get; set; }

        [MaxLength(122)]
        public string Name { get; set; }

        public List<CountryTrip> CountryTrips { get; set; } = new List<CountryTrip>();
    }
}