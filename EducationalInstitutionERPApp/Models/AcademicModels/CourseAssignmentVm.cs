using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;

namespace EducationalInstitutionERPApp.Models.AcademicModels
{
    public class CourseAssignmentVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select department")]
        [DisplayName("Depaertment")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please select Course")]
        [DisplayName("Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please select Teacher")]
        [DisplayName("Teacher")]
        public int TeacherId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public double CourseCredit { get; set; }
        public double CreditTaken { get; set; }
        public string Message { get; set; }
        public List<Employee> Employees { get; set; }
        public string SemesterName { get; set; }
        public string TeacherName { get; set; }
    
        public List<Course> Courses { get; set; }
    }
}