using System.ComponentModel.DataAnnotations;

namespace Tui.Presentation.Models
{
    public class AirPortViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(160)]
        public string NameAirport { get; set; }
        [Required]
        public  string CityOfAirport { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}