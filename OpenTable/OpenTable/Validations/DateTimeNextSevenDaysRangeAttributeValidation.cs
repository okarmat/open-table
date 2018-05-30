using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenTable.Validations
{
    public class DateTimeNextSevenDaysRangeAttributeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {            
            var dateTimeValue = (DateTime)value;

            if (dateTimeValue >= DateTime.Now && dateTimeValue <= DateTime.Now.AddDays(7))
                return ValidationResult.Success;
            else
                return new ValidationResult("Data rezerwacji musi się zawierać w przeciągi kilku najbliższych dni");
        }
    }
}