using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tui.BusinessEntities;
using Tui.BusinessEntities.Entities;
using Tui.DataAccess.Context;
using Tui.DataAccessInterfaces.Repositories;

namespace Tui.DataAccess.Repositories
{
    public class FlightRepository : Repository<Flight> ,IFlightRepository
    {
        
    }



}
