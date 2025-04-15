using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RealCash.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter Name plz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your PIN")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "PIN must be exactly 4 digits.")]
        public int Pin { get; set; }
    }
}