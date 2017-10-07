using PayrollProject.Repositories.Context;
using PayrollProject.Repositories.RepositotyInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject.Repositories.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private SmartPayrollContext dataContext;
        private readonly IDbSet<T> dbset;
        protected RepositoryBase(IDataBaseFactory databaseFactory)
        {
            DataBaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }
        protected IDataBaseFactory DataBaseFactory
        {
            get;
            private set;
        }
        protected SmartPayrollContext DataContext
        {
            get { return dataContext ?? (dataContext = DataBaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }


        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
    }
}
