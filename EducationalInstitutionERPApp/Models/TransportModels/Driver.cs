using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.TransportModels
{
    public class Driver
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Driver's Name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Contact No.")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Contact no must be between 11 to 14 digit")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Contact no must be numeric")]
        [DisplayName("Contact No.")]
        public string ContactNo { get; set; }
        [DisplayName("License No.")]
        [Required(ErrorMessage = "Please Enter License No.")]
        public string LicenseNo { get; set; }
        
        public HttpPostedFileBase DriverImage { get; set; }
        public byte[] DImage { get; set; }
    }
}