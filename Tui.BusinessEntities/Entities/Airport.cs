using System.Collections.Generic;
using Tui.BusinessEntities;

namespace Tui.BusinessEntities.Entities
{
    public class Airport : BaseEntity
    {
       // public virtual int Id { get; set; }

        public virtual string NameAirport { get; set; }

        public virtual string CityOfAirport { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }

        public virtual ICollection<AirPlane> AirPlane { get; set; }
        public virtual ICollection<Flight> Flight { get; set; }


    }
}
