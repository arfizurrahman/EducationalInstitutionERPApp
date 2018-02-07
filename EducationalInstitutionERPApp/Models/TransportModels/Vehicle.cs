using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EducationalInstitutionERPApp.Models.TransportModels
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter The Vehicle No.")]
        [DisplayName("Vehicle No.")]
        public String VehicleNo { get; set; }
        [Required(ErrorMessage = "Please Enter Number of seats.")]
        [DisplayName("No Of Seats")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Contact no must be numeric")]
        public int NoOfSeats { get; set; }
        [Required(ErrorMessage = "Please Select Vehicle Type.")]
        [DisplayName("Vehicle Type")]
        public int VehicleTypeId { get; set; }
        [Required(ErrorMessage = "Please Select Vehicle Type.")]
        [DisplayName("Vehicle Type")]
        public string VehicleType { get; set; }
        [Required(ErrorMessage = "Please Enter Driver's Name.")]
        [DisplayName("Driver's Name")]
        public int DriverId { get; set; }
        [Required(ErrorMessage = "Please Enter Driver's Name.")]
        [DisplayName("Driver's Name")]
        public string DriverName { get; set; }

    }
}