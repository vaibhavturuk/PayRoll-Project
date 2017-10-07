using Microsoft.AspNet.Identity.EntityFramework;
using PayrollProject.Entities.Infrastructure;
using PayrollProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject.Repositories.Context
{
    public class SmartPayrollContext : DbContext
    {
        public SmartPayrollContext() : base("MyConnectionString")
        {
        }
        public DbSet<Employee> Employees { get; set; }
      


        public virtual void Commit()
        {
            base.SaveChanges();
        }

    }
}
