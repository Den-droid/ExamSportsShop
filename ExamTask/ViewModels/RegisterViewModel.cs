using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTask.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Middle Name")]
        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }


        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must be at least 8 characters long, " +
            "contain 1 lowercase letter, 1 uppercase letter, 1 special symbol and 1 number")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter password confirmation")]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}