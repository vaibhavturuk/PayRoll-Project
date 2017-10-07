
using AutoMapper;
using PayrollProject.Entities.Models;
using PayrollProject.Repositories.Repositories;
using PayrollProject.Repositories.RepositotyInterfaces;
using PayrollProject.Services.ServiceInterfaces;
using PayrollProject.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository empRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeService(IEmployeeRepository empRepository, IUnitOfWork unitOfWork)
        {
            this.empRepository = empRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<EmployeeViewModel> GetAllCustomers()
        {
            return empRepository.GetAll().Select(Mapper.Map<Employee, EmployeeViewModel>);
            //return companyRepository.GetAll();
        }

        public void AddUser(EmployeeViewModel employeevm)
        {

            var employee = Mapper.Map<EmployeeViewModel, Employee>(employeevm);
            //_context.Customers.Add(customer);
            //_context.SaveChanges();
            empRepository.Add(employee);
            unitOfWork.Commit();
        }

    }
}
