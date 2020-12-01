using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual string TextAddress { get; set; }
    }

    public class Description
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual string TextDescription { get; set; }
        [Required]
        public virtual DateTime Date { get; set; }
        [Required]
        public virtual Location Location { get; set; }
    }

    public class VolonterEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual VolonterOrganization VolonterOrganization { get; set; }
        [Required]
        public virtual Description Description { get; set; }
    }

    public class UpcomingVolonterEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual VolonterEvent VolonterEvent { get; set; }
        public virtual ICollection<Volonter> Volonters { get; set; }
    }

    public class InProgressVolonterEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual VolonterEvent VolonterEvent { get; set; }
        public virtual ICollection<Volonter> Volonters { get; set; }
    }

    public class FinishedVolonterEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual VolonterEvent VolonterEvent { get; set; }
        public virtual ICollection<Volonter> Volonters { get; set; }
        public virtual ICollection<EventFeedback> EventFeedbacks { get; set; }
    }
}