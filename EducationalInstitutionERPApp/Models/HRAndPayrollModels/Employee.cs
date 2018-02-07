using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.HRAndPayrollModels
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
      
        public string Name { get; set; }

        public byte[] EmpImage { get; set; }
        public HttpPostedFileBase EmployeeImage { get; set; }
        [Required(ErrorMessage = "Please select Gender")]
        
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please select Gender")]
        [DisplayName("Gender")]
        public int GenderId { get; set; }
        [Required(ErrorMessage = "Please select date of birth")]
        [DisplayName("Date Of Birth")]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please select joining date")]
        [DisplayName("Joining Date")]
        public string JoiningDate { get; set; }
        [Required(ErrorMessage = "Please select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please select Department")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Please select designation")]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please select designation")]
       
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please select Category")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please select Category")]
        
        public string Category { get; set; }
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid email")]
        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Contact No")]
        
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Credit")]
        public double Credit { get; set; }

        public string Message { get; set; }
    }
}