using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Models.AcademicModels;

namespace EducationalInstitutionERPApp.Models.StudentModels
{
    public class CourseEnrollmentVm
    {
        [Required(ErrorMessage = "Please select registration no.")]
        [DisplayName("Reg. No")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please select course.")]
        [DisplayName("Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Enter Course Name")]
        [DisplayName("Name")]
        public String CourseName { get; set; }
        [Required(ErrorMessage = "Please Enter Course Code")]

        [StringLength(20, MinimumLength = 5, ErrorMessage = "code length Minimum 5 characters")]
        [DisplayName("Code")]
        public String Code { get; set; }
        
        [Required(ErrorMessage = "Please enter Name")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please select date")]
        [DisplayName("Date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter valid email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Contact No")]

        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please select Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please select Department")]
        public string Department { get; set; }
        
        public double Credit { get; set; }
        [Required(ErrorMessage = "Please select registration no.")]
        [DisplayName("Reg. No")]
        public string RegNo { get; set; }
        public string Message { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }

        
    }
}