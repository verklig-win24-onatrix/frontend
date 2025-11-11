using System.ComponentModel.DataAnnotations;

namespace UmbracoCMS.ViewModels;

public class QuestionFormViewModel
{
  [Display(Name = "Name")]
  [Required(ErrorMessage = "Name is required")]
  public string Name { get; set; } = null!;

  [Display(Name = "Email")]
  [Required(ErrorMessage = "Email is required")]
  [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address")]
  public string Email { get; set; } = null!;

  [Display(Name = "Question")]
  [Required(ErrorMessage = "Question is required")]
  public string Question { get; set; } = null!;
}