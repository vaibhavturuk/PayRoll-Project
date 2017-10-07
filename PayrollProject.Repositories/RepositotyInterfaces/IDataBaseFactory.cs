using PayrollProject.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject.Repositories.RepositotyInterfaces
{
    public interface IDataBaseFactory : IDisposable
    {
        SmartPayrollContext Get();
    }
}
