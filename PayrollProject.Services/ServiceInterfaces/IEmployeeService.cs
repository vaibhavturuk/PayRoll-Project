using PayrollProject.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject.Services.ServiceInterfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAllCustomers();
        void AddUser(EmployeeViewModel employee);
    }
}
