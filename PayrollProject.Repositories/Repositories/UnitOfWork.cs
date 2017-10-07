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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataBaseFactory databaseFactory;
        private SmartPayrollContext dataContext;
        public UnitOfWork(IDataBaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }
        protected SmartPayrollContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }
        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
