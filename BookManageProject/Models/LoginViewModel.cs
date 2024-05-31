﻿using System.ComponentModel.DataAnnotations;

namespace BookManageProject.Models
{
    public class LoginViewModel
    {
        [Required]
        public string? EmailAddress {  get; set; }
        [Required]
        public string? Password {  get; set; }
    }
}
