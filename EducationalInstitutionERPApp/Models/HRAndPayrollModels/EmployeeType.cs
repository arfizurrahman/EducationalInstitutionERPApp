using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.HRAndPayrollModels
{
    public class EmployeeType
    {
        public int Id{ get; set; }
        [Required(ErrorMessage = "Please Enter Employee Type")]
        [DisplayName("Employee Type")]
        public string EmpType { get; set; }
    }
}