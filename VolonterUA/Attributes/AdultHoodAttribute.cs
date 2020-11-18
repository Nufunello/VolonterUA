using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolonterUA.Attributes
{
    public class AdultHoodAttribute : ValidationAttribute
    {
        private static int AdultYears => 18;
        private readonly bool shouldBeAdult;
        public AdultHoodAttribute(bool shouldBeAdult = true)
        {
            this.shouldBeAdult = shouldBeAdult;
        }

        private bool IsValid(DateTime value)
        {
            return shouldBeAdult ? DateTime.Now.AddDays(-AdultYears) >= value : DateTime.Now.AddDays(-AdultYears) < value;
        }

        public override bool IsValid(object value)
        {
            DateTime? val = value as DateTime?;
            return val != null && IsValid(val.Value);
        }
    }
}