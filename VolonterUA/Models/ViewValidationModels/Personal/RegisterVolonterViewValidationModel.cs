using System;
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
        public UserLoginDataModel UserLoginData { get; set; }
    }
}