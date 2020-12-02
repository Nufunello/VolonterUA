using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VolonterUA.Models.Database;

namespace VolonterUA.Models.ViewValidationModels.Home
{
    public class RegisterEventViewValidationModel
    {
        [Required]
        public VolonterEvent VolonterEvent { get; set; }
    }
}