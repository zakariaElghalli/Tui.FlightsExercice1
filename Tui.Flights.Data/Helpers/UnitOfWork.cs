using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Tui.Flights.Data.MappingOverrides;
using Tui.Flights.Domain.Entities;
using Tui.Flights.Domain.Helpers;

namespace Tui.Flights.Data.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory SessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork() 
        {
            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("FlightsConnectionString")))
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<AirCraft>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<AirCraftOverrides>()))
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<AirPort>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<AirPortOverrides>()))
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<Flight>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<FlightOverrides>()))
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = SessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch 
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
