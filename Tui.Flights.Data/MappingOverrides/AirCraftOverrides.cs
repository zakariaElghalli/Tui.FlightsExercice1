using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Tui.Flights.Domain.Entities;

namespace Tui.Flights.Data.MappingOverrides
{    
    public class AirCraftOverrides : IAutoMappingOverride<AirCraft>
    {
        public void Override(AutoMapping<AirCraft> mapping)
        {
        }
    }
}
