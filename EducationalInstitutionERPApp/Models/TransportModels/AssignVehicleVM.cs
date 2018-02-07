using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.TransportModels
{
    public class AssignVehicleVM
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Please select vehicle no")]
        [DisplayName("Vehicle No")]
        public string VehicleNo { get; set; }
        [Required(ErrorMessage = "Please select vehicle type")]
        [DisplayName("Vehicle Type")]
        public int VehicleTypeId { get; set; }
        [Required(ErrorMessage = "Please select vehicle type")]
        [DisplayName("Vehicle Type")]
        public string VehicleType { get; set; }

        public int RouteId { get; set; }
        [Required(ErrorMessage = "Please select route code")]
        [DisplayName("Route Code")]
        public string RouteCode { get; set; }
        [Required(ErrorMessage = "Please enter start time")]
        [DisplayName("Start Time")]
        public string StartTime { get; set; }
        [Required(ErrorMessage = "Please select user type")]
        [DisplayName("User Type")]
        public string UserType { get; set; }

        [Required(ErrorMessage = "Please Enter start place")]
        [DisplayName("Start Place")]
        public string StartPlace { get; set; }
        [DisplayName("End Place")]
        [Required(ErrorMessage = "Please Enter end place")]
        public string EndPlace { get; set; }

        
    }
}