#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace dojoSurveyClone.Models;

public class User
{
    [Required]
    [NoZNames]
    [MinLength(2, ErrorMessage = "Name must at least be 2 characters!")]
    public string Name { get; set; }

    [Required]
    [DisplayName("Your Location")]
    public string Location { get; set; }

    [Required]
    [DisplayName("Favorite Language")]
    public string Language { get; set; }

    [MinLength(20, ErrorMessage = "Comment must be at least 20 characters!")]
    public string? Comment { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime Birthday { get; set; }
}


// CUSTOM VALIDATIONS
// Create a class that inherits from ValidationAttribute
public class NoZNamesAttribute : ValidationAttribute
{
    // Call upon the protected IsValid method
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // We are expecting the value coming in to be a string
        // so we need to do a bit of type casting to our object
        // Strings work similarly to arrays under the hood 
        // so we can grab the first letter using its index   
        // If we discover that the first letter of our string is z...  
        if (((string)value).ToLower()[0] == 'z')
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("No names that start with Z allowed!");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Birthday must be in the past");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

