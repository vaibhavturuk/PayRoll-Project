using PayrollProject.Services.ServiceInterfaces;
using PayrollProject.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PayrollProject.Web.Controllers
{
    [EnableCors(origins: "http://localhost:4201", headers: "*", methods: "*")]
    public class PayRollController : ApiController
    {
        private readonly IEmployeeService customerRepository;



        public PayRollController(IEmployeeService userRepo)
        {
            this.customerRepository = userRepo;
           
           

        }
       /// <summary>
       /// get employee data
       /// </summary>
       /// <returns></returns>

        //[Route("api/PayRoll/Get/")]
        [HttpGet]
        public IEnumerable<EmployeeViewModel> Get()
        {
            try
            {
                return customerRepository.GetAllCustomers();

            }
            catch (System.Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// poet employee data
        /// </summary>
        /// <param name="person"></param>
        //[Route("api/PayRoll/post/")]
        [HttpPost]

        public void post(EmployeeViewModel person)
        {
            customerRepository.AddUser(person);
        }
       
    }
}
