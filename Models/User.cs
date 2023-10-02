#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace dojoSurveyClone.Models;

public class User
{
    [Required]
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
}
