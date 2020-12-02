using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class Organizator
    {
        [Key]
        [ForeignKey("UserInfo")]
        public virtual int Id { get; set; }
        [Required]
        public virtual UserInfo UserInfo { get; set; }
        [Required]
        public virtual VolonterOrganization VolonterOrganization { get; set; }
    }
}