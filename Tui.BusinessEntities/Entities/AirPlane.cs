using System.Collections.Generic;

namespace Tui.BusinessEntities.Entities
{
    public class AirPlane : BaseEntity
    {
        //public virtual int Id { get; set; }

        public virtual string AirPlaneName { get; set; }

        public virtual double TakeOffEffort { get; set; }

        public virtual double Speed { get; set; }

       

        public virtual double Consumption { get; set; }

        public virtual ICollection<Flight> Flight { get; set; }
    }
}
