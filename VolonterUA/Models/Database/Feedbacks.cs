using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VolonterUA.Models.Database
{
    public class VolonterOrganizationFeedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual Volonter Volonter { get; set; }
        [Required]
        [Range(1, 10)]
        public virtual int Mark { get; set; }
    }

    public class EventFeedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        public virtual FinishedVolonterEvent FinishedVolonterEvent { get; set; }
        [Required]
        public virtual Volonter Volonter { get; set; }
        [Required]
        [Range(1, 10)]
        public virtual int Mark { get; set; }
        public virtual string Comment { get; set; }
    }
}