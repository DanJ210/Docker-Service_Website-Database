﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models.ViewModels {
    public class LoginViewModel {
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Rememeber Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
