using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject.Repositories.RepositotyInterfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        //void Start();
    }
}
