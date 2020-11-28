using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolonterUA.Models.Database
{
    public class Address
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string TextAddress { get; set; }
    }

    public class Description
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual string TextDescription { get; set; }
        [Required]
        public virtual Address Address { get; set; }
    }

    public class VolonterEvent
    {
        public virtual int Id { get; set; }
        public virtual ICollection<VolonterOrganization> Organizations { get; set; }
        [Required]
        public virtual Description Description { get; set; }
    }

    public class UpcomingVolonterEvent
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual VolonterEvent VolonterEvent { get; set; }
        public virtual ICollection<UserInfoModel> Subscribers { get; set; }
    }

    public class InProgressVolonterEvent
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual VolonterEvent VolonterEvent { get; set; }
        public virtual ICollection<UserInfoModel> VolontersAtEvent { get; set; }
    }

    public class FinishedVolonterEvent
        : InProgressVolonterEvent
    {
        public virtual ICollection<EventFeedback> VolontersFeedbacks { get; set; }
    }
}