namespace Tui.Flights.Domain.Entities
{
    public class AirCraft : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Model { get; set; }

        public virtual double AverageSpeed { get; set; }

        public virtual double TakeOffEffort { get; set; }

        public virtual double FuelConsumptionPerHour { get; set; }
    }
}
