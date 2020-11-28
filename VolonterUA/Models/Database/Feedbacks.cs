using System.ComponentModel.DataAnnotations;

namespace VolonterUA.Models.Database
{
    public enum Mark
        : int
    {
        Zero = 0,
        One,
        Two,
        Three,
        Five
    }

    public abstract class AFeedback
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual Mark Mark { get; set; }
    }

    public class VolonterOrganizationFeedback
        : AFeedback
    {
        [Required]
        public virtual UserInfoModel Volonter { get; set; }
    }

    public class EventFeedback
        : AFeedback
    {
        public virtual string Comment { get; set; }
    }
}