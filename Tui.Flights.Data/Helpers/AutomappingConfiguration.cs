using FluentNHibernate.Automapping;
using System;
using Tui.Flights.Domain.Entities;

namespace Tui.Flights.Data.Helpers
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterface(typeof(IEntity).FullName) != null;
        }
    }
}
