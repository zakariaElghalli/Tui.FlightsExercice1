using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tui.BusinessEntities.Entities;

namespace Tui.Presentation.Models
{
    public class FlightViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public int AirPlaneId { get; set; }
        [Required]
        public int DepartureAirportId { get; set; }
        [Required]
        public int ArrivalAirportId { get; set; }
        [Required]
        public double Distance { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public double FuelConsumption { get; set; }

        public string AirPlaine { get; set; }

        public string DeparturAirport { get; set; }

        public string ArrivalAirport { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IEnumerable<AirPortViewModel> DeparturAeroports { get; set; }
        public IEnumerable<AirPortViewModel> ArrivalAeroports { get; set; }
        public IEnumerable<AirPlaneViewModel> AirPlanes { get; set; }
    }
}