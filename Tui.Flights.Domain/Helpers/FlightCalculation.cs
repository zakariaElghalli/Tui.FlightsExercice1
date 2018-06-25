using System.Device.Location;
using Tui.Flights.Domain.Entities;

namespace Tui.Flights.Domain.Helpers
{
    public static class FlightCalculation
    {      
        public static double GetDistance(AirPort departureAirport, AirPort arrivalAirport)
        {
            var sCoord = new GeoCoordinate(departureAirport.Latitude, departureAirport.Longitude);
            var eCoord = new GeoCoordinate(arrivalAirport.Latitude, arrivalAirport.Longitude);

            return sCoord.GetDistanceTo(eCoord);
        }
    }
}
