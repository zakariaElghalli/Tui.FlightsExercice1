using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Tui.Flights.Domain.Entities;

namespace Tui.Flights.Data.MappingOverrides
{
    public class AirPortOverrides : IAutoMappingOverride<AirPort>
    {
        public void Override(AutoMapping<AirPort> mapping)
        {
        }
    }
}
