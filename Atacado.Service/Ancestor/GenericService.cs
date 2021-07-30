using Atacado.Mapping.Ancestor;
using Atacado.Repository.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Ancestor
{
    public abstract class GenericService<TContext, TDomain, TPoco> : IDisposable
        where TContext : DbContext
        where TDomain : class
        where TPoco : class
    {
        protected GenericRepository<TContext, TDomain> repositorio;

        protected BaseMapping mapa;


        public void Dispose()
        {
            this.repositorio = null;
            this.mapa = null;
        }
    }
}
