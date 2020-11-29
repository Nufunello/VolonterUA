using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VolonterUA.Models.Database
{
    public class Volonter
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual UserInfoModel User { get; set; }
        public virtual ICollection<FinishedVolonterEvent> WasVolonterAt { get; set; }
        public virtual ICollection<UpcomingVolonterEvent> SubscribedAt { get; set; }
        public virtual int Karma { get; set; }
    }
}