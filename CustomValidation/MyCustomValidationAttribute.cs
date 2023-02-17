
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication3.CustomValidation
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                string fullName = value.ToString();
                if(fullName!=null)
                {
                    return ValidationResult.Success;
                }

            }
            return new ValidationResult("FirstName is empty please enter name");
        }
    }
}