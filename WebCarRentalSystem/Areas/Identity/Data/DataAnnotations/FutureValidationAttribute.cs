using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.Areas.Identity.Data.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class FutureValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            return value is DateTime dateTime && dateTime > DateTime.UtcNow.Date
                ? ValidationResult.Success
                : new ValidationResult("Date must be in the future");
        }
    }
}
