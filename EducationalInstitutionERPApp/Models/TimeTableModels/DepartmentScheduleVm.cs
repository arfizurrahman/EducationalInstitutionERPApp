using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.TimeTableModels
{
    public class DepartmentScheduleVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Time { get; set; }
        public string Semester { get; set; }
        [Required(ErrorMessage = "Please select Semester")]
        [DisplayName("Semester")]
        public int SemesterId { get; set; }
        public string RoomNo { get; set; }
        public int CourseId { get; set; }
        public string BuildingName { get; set; }
        public int BuildingId { get; set; }
        public int RoomId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Allocate { get; set; }
        public string Day { get; set; }
        public string Schedule { get; set; }

        public List<Schedule> Schedules { get; set; }
        public List<TimeTableVM> DeptTimeTables { get; set; }
    }
}