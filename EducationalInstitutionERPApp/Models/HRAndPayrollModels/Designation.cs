using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.HRAndPayrollModels
{
    public class Designation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Designation")]
        [DisplayName("Designation")]
        public string DesignationName { get; set; }
    }
}