using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Project.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="please add your name")]
        [Display(Name="Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "please add your Birthday")]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "please add your Register Date")]
        [Display(Name = "Register Date")]
        public DateTime RegisteredDate { get; set; }

        [Required(ErrorMessage = "please add your A/L Stream")]
        [Display(Name = "A/L Stream")]
        public String ALStream { get; set; }
    }
}
