using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.StudentModels
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]

        public string Name { get; set; }

       
        [Required(ErrorMessage = "Please select Gender")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "Please select Gender")]
        [DisplayName("Gender")]
        public int GenderId { get; set; }
        [Required(ErrorMessage = "Please select date of birth")]
        [DisplayName("Date Of Birth")]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please select registration date")]
        [DisplayName("Reg. Date")]
        public string RegistrationDate { get; set; }
        [Required(ErrorMessage = "Please select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please select Department")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid email")]
        
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Contact No")]

        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Credit")]
        public double Credit { get; set; }

        public string RegNo { get; set; }
        public string Message { get; set; }
    }
}