using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VolonterUA.Models.Database
{
    public class Volonter
    {
        [Required]
        [Key]
        [ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual InProgressVolonterEvent InProgressVolonterEvent { get; set; }
        public virtual ICollection<UpcomingVolonterEvent> UpcomingVolonterEvents { get; set; }
        public virtual ICollection<FinishedVolonterEvent> FinishedVolonterEvents { get; set; }
        public virtual int Karma { get; set; }
    }
}