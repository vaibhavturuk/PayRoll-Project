using AutoMapper;
using PayrollProject.Entities.Models;
using PayrollProject.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollProject.Web.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
          

        }
    }
}