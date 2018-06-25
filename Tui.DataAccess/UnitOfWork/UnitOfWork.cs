﻿using System;
using System.Collections.Generic;
using Tui.BusinessEntities;
using Tui.DataAccess.Context;
using Tui.DataAccess.Repositories;
using Tui.DataAccessInterfaces.Repositories;
using Tui.DataAccessInterfaces.UnitOfWork;

namespace Tui.DataAccess
{
    public class UnitOfWork : IDisposable , IUnitOfWork
    {
        private readonly TuiTestContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork(TuiTestContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            context = new TuiTestContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }
    }
}
