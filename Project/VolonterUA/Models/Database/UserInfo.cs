using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VolonterUA.Attributes;

namespace VolonterUA.Models.Database
{
    public enum Activity
    {
        Volonter = 0,
        Organization
    }

    public class UserInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        [RegularExpression(@"(^([a-zA-Z]+(['-a-zA-Z][a-zA-Z])|([a-zA-Z]))*$)|(^\s*[А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ]+([-'А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ][А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ])([А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ])*$)")]
        public virtual string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        [RegularExpression(@"(^([a-zA-Z]+(['-a-zA-Z][a-zA-Z])|([a-zA-Z]))*$)|(^\s*[А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ]+([-'А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ][А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ])([А-Яа-яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ])*$)")]
        public virtual string LastName { get; set; }
        [Required]
        [AdultHood]
        [DataType(DataType.Date)]
        public virtual DateTime Birthdate { get; set; }
        [Required]
        [RegularExpression(@"^\+?(38)?(0(67|50|68|96|97|98|66|95|99)\d{7})$")]
        public virtual string PhoneNumber { get; set; }
        public virtual Volonter Volonter { get; set; }
        public virtual Organizator Organizator { get; set; }
        public virtual Activity Activity { get; set; }
    }
}