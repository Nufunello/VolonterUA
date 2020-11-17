using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class UserInfoModel
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public virtual string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public virtual string LastName { get; set; }
        [Required]
        public virtual DateTime Birthdate { get; set; }
        [Required]
        [RegularExpression(@"^\+?3?8?(0[5-9][0-9]\d{7})$")]
        public virtual string PhoneNumber { get; set; }
    }
}