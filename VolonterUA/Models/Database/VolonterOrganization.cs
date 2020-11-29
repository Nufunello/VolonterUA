using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class VolonterOrganization
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual UserInfoModel Representative { get; set; }
        public virtual ICollection<VolonterOrganizationFeedback> Feedbacks { get; set; }
        public virtual ICollection<UpcomingVolonterEvent> UpcomingVolonterEvents { get; set; }
        public virtual ICollection<InProgressVolonterEvent> InProgressVolonterEvents { get; set; }
        public virtual ICollection<FinishedVolonterEvent> FinishedVolonterEvents { get; set; }
    }
}