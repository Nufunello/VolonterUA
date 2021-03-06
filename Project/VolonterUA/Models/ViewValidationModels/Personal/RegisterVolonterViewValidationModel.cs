﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VolonterUA.Models.Database;

namespace VolonterUA.Models.ViewValidationModels.Personal
{
    public class RegisterVolonterViewValidationModel
        : AViewValidationModel
    {
        [Required]
        public UserLoginData UserLoginData { get; set; }
    }
}