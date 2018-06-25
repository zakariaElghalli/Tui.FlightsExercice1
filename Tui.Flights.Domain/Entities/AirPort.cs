namespace Tui.Flights.Domain.Entities
{
    public class AirPort : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }
    }
}
