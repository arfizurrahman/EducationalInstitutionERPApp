using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.TransportModels
{
    public class UserDestinationAllocation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select route code.")]
        [DisplayName("Route Code")]
        public string RouteCode { get; set; }
        public int RouteId { get; set; }
        public int DestinationId { get; set; }
        [Required(ErrorMessage = "Please select Destination.")]
        
        public string Destination { get; set; }
        [Required(ErrorMessage = "Please select user type.")]
        public string Type { get; set; }

        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please select department.")]
        public string Department { get; set; }

        
        [Required(ErrorMessage = "Please select Reg No.")]
        [DisplayName("Reg No.")]
        public string RegNo { get; set; }
        public string Name { get; set; }
    }
}