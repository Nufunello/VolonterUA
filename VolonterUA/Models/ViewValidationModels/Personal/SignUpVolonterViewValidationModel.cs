using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VolonterUA.Models.Database;

namespace VolonterUA.Models.ViewValidationModels.Personal
{
    public class SignUpVolonterViewValidationModel
        : AViewValidationModel
    {
        public UserLoginDataModel UserLoginDataModel { get; set; }
    }
}