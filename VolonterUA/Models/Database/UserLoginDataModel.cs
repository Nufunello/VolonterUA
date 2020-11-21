using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class UserLoginDataModel
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }
        [Required]
        public virtual UserInfoModel UserInfo { get; set; }
        [Required]
        [RegularExpression(@"^\s*[a-zA-Z]+\s*$")]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public virtual string Login { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d)(?=.*[A-Z])(?=.*[$&+,:;=?@#|'<>.^*()%!-]).*$")]
        public virtual string Password { get; set; }
    }
}