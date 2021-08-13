using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspApp.Models
{
    public class RegisterUserViewModel
    {
       // [FirstName]
        public string FirstName { get; set; }
       // [LastName]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation does not match.")]
        public string ConfirmPassword { get; set; }
    }
}

