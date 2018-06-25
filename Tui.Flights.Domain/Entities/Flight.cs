namespace Tui.Flights.Domain.Entities
{
    public class Flight : IEntity
    {
        public virtual int Id { get; set; }

        public virtual int AirCraftId { get; set; }

        public virtual int DepartureAirportId { get; set; }

        public virtual int ArrivalAirportId { get; set; }

        public virtual double Distance { get; set; }

        public virtual double Duration { get; set; }

        public  virtual  double FuelConsumption { get; set; }
    }
}
