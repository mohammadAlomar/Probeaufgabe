﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Probeaufgabe.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password Feld do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
