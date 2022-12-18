using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.Areas.Identity.Data.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CarRentedValidationAttribute : ValidationAttribute
    {
        //protected override ValidationResult? IsValid(object? value, ValidationContext context)
        //{
        //    return value is true ? ValidationResult.Success
        //        : new ValidationResult("This car is already rented");
        //}
    }
}
