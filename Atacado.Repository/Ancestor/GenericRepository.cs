using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Ancestor
{
    public abstract class GenericRepository<TContext, TDomain> : IRepository<TDomain>
        where TContext : DbContext
        where TDomain : class
    {
        protected TContext context;

        public GenericRepository(TContext context)
        {
            this.context = context;
        }

        public IEnumerable<TDomain> Browse()
        {
            return this.Browsable().AsEnumerable();
        }

        public IQueryable<TDomain> Browsable()
        {
            return this.context.Set<TDomain>().AsQueryable();
        }

        public TDomain Read(Expression<Func<TDomain, bool>> parameters)
        {
            return this.Browsable().SingleOrDefault(parameters);
        }

        public TDomain Edit(TDomain instance)
        {
            this.context.Entry<TDomain>(instance).State = EntityState.Modified;
            this.context.SaveChanges();
            return instance;
        }

        public TDomain Add(TDomain instance)
        {
            this.context.Set<TDomain>().Add(instance);
            this.context.SaveChanges();
            return instance;
        }

        public TDomain Delete(TDomain instance)
        {
            this.context.Entry<TDomain>(instance).State = EntityState.Deleted;
            this.context.SaveChanges();
            return instance;
        }
    }
}
