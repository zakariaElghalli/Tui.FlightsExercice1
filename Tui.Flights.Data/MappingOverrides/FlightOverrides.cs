using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Tui.Flights.Domain.Entities;

namespace Tui.Flights.Data.MappingOverrides
{    
    public class FlightOverrides : IAutoMappingOverride<Flight>
    {
        public void Override(AutoMapping<Flight> mapping)
        {
        }
    }
}
