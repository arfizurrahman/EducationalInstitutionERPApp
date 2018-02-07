using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "password length must be atleast 8")]
        public string Password { get; set; }


    }
}