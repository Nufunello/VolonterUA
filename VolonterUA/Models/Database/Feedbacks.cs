using System.ComponentModel.DataAnnotations;

namespace VolonterUA.Models.Database
{
    public abstract class AFeedback
    {
        public virtual int Id { get; set; }
        [Required]
        [Range(1,10)]
        public virtual int Mark { get; set; }
    }

    public class VolonterOrganizationFeedback
        : AFeedback
    {
        [Required]
        public virtual Volonter Volonter { get; set; }
    }

    public class EventFeedback
        : AFeedback
    {
        public virtual string Comment { get; set; }
    }
}