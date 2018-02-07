using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.TimeTableModels
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string Course { get; set; }
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Allocate { get; set; }
        public string Building { get; set; }
        public string Category { get; set; }
        [DisplayName("Building")]
        public int BuildingId { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}