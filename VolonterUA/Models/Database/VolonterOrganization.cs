using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class VolonterOrganization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual UserInfo Representative { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual ICollection<VolonterOrganizationFeedback> VolonterOrganizationFeedbacks { get; set; }
        public virtual ICollection<UpcomingVolonterEvent> UpcomingVolonterEvents { get; set; }
        public virtual ICollection<InProgressVolonterEvent> InProgressVolonterEvents { get; set; }
        public virtual ICollection<FinishedVolonterEvent> FinishedVolonterEvents { get; set; }
    }
}