


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkApi.Models{

    [Table("Country_Trip", Schema = "trip")]
    public class CountryTrip
    {
        [Key, Column(Order = 0)]
        public int IdCountry { get; set; }

        [Key, Column(Order = 1)]
        public int IdTrip { get; set; }
        
        [ForeignKey("IdCountry")]
        public Country Country { get; set; }
        
        [ForeignKey("IdTrip")]
        public Trip Trip { get; set; }
    }
}