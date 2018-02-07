using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.TransportModels
{
    public class RouteVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter route code")]
        [DisplayName("Route Code")]
        public string RouteCode { get; set; }
        
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Please Select a Vehicle.")]
        [DisplayName("Vehicle No.")]
        public string VehicleNo { get; set; }
        [Required(ErrorMessage = "Please Enter start place")]
        [DisplayName("Start Place")]
        public string StartPlace { get; set; }
        [DisplayName("End Place")]
        [Required(ErrorMessage = "Please Enter end place")]
        public string EndPlace { get; set; }
    }
}