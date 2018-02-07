using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.TransportModels
{
    public class Destination
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter route code")]
        [DisplayName("Route Code")]
        public int RouteId { get; set; }
        public string RouteCode { get; set; }
        [Required(ErrorMessage = "Please Enter Pickuo and Drop Place")]
        [DisplayName("Pickup & Drop")]
        public string PickUpAndDrop { get; set; }
  
        [Required(ErrorMessage = "Please Enter Fee Amount")]
        [DisplayName("Fee Amount")]
        public int FeeAmount { get; set; }
        [Required(ErrorMessage = "Please select fee type.")]
        [DisplayName("Fee Type")]
        public int FeeTypeId { get; set; }
        public string FeeType { get; set; }
        
    }
}