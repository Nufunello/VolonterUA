﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VolonterUA.Attributes
{
    public class AdultHoodAttribute : ValidationAttribute, IClientValidatable
    {
        private static int AdultYears => 18;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime? val = value as DateTime?;
            return (val != null && DateTime.Now.AddDays(-AdultYears) >= val) ? ValidationResult.Success : new ValidationResult("");
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ValidationParameters.Add("adultyears", AdultYears.ToString());
            rule.ValidationType = "adulthoodvalidate";
            yield return rule;
        }
    }
}