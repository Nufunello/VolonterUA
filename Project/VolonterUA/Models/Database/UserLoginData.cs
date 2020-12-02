using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class UserLoginData
    {
        [Key]
        [ForeignKey("UserInfo")]
        public virtual int Id { get; set; }
        [Required]
        public virtual UserInfo UserInfo { get; set; }
        [Required]
        [RegularExpression(@"^\s*[a-z_A-Z0-9]+\s*$")]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public virtual string Login { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d)(?=.*[A-Z])(?=.*[$&+,:;=?@#|'<>.^*()%!-]).*$")]
        public virtual string Password { get; set; }
    }
}