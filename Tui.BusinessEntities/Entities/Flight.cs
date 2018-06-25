
using System.ComponentModel.DataAnnotations.Schema;
using Tui.BusinessEntities;

namespace Tui.BusinessEntities.Entities
{
    public class Flight : BaseEntity
    {
        //   public virtual int Id { get; set; }

        //public virtual int AirCraftId { get; set; }
        [ForeignKey("AirPlaneId")]
        public virtual  AirPlane AirPlane { get; set; }
        public int AirPlaneId { get; set; }


      
      [ForeignKey("DepartureAirportId")]
        public virtual  Airport Airport { get; set; }
        
        public  int DepartureAirportId { get; set; }

      
        public  int ArrivalAirportId { get; set; }



    
        
      


        public double FuelConsumption { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
      
    }
}
