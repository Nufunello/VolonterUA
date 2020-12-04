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
        [Key]
        [ForeignKey("Organizator")]
        public virtual int Id { get; set; }
        public virtual Organizator Organizator { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        [RegularExpression(@"(^\s*([a-zA-Z ]+([-a-zA-Z][a-zA-Z])|([a-zA-Z ]))*\s*$)|(^\s*[А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ ]+([-А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ][А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ])([А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ ])*\s*$)")]
        public virtual string Name { get; set; }
        public virtual ICollection<VolonterOrganizationFeedback> VolonterOrganizationFeedbacks { get; set; }
        public virtual ICollection<UpcomingVolonterEvent> UpcomingVolonterEvents { get; set; }
        public virtual ICollection<InProgressVolonterEvent> InProgressVolonterEvents { get; set; }
        public virtual ICollection<FinishedVolonterEvent> FinishedVolonterEvents { get; set; }
    }
}