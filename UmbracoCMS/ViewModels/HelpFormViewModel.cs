using System.ComponentModel.DataAnnotations;

namespace UmbracoCMS.ViewModels;

public class HelpFormViewModel
{
  [Display(Name = "Email")]
  [Required(ErrorMessage = "Email is required")]
  [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address")]
  public string Email { get; set; } = null!;
}