using System.ComponentModel.DataAnnotations;

namespace Tui.Presentation.Models
{
    public class AirPlaneViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(160)]
        public string AirPlaneName { get; set; }
        [Required]
        public decimal Speed { get; set; }
        [Required]
        public double TakeOffEffort { get; set; }
        [Required]
        public double FuelConsumptionPer100Km { get; set; }
        [Required]
        public  double Consumption { get; set; }
        
    }
}