using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Project.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please add your name")]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "please add your Role")]
        [Display(Name = "Role")]
        public String Role { get; set; }

        [Required(ErrorMessage = "please add your Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }

        [Required(ErrorMessage = "please add your Password")]
        [Display(Name = "Password")]
        [MinLength(4)]
        public String Password { get; set; }


    }
}
