using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject.Entities.Models
{
    public class Employee : BaseModel
    {

        [Required(ErrorMessage = "Your Employee Code ")]
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage = "Your First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your Last Name ")]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date of Birthday")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Enter Your Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Maritial Status is Required ")]
        public bool MaritalStatus { get; set; }

        [Required(ErrorMessage = "Your Job Title ")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Your Mobile Number")]
        public string MobileNumber { get; set; }


    }
}
