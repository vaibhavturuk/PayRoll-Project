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
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private SmartPayrollContext dataContext;
        public SmartPayrollContext Get()
        {
            return dataContext ?? (dataContext = new SmartPayrollContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
