using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UmbracoCMS.ViewModels;

public class CallbackFormViewModel
{
  [Display(Name = "Name")]
  [Required(ErrorMessage = "Name is required")]
  public string Name { get; set; } = null!;

  [Display(Name = "Email")]
  [Required(ErrorMessage = "Email is required")]
  [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address")]
  public string Email { get; set; } = null!;

  [Display(Name = "Phone")]
  [Required(ErrorMessage = "Phone is required")]
  public string Phone { get; set; } = null!;

  [Required(ErrorMessage = "An option is required")]
  public string SelectedOption { get; set; } = null!;

  [BindNever]
  public IEnumerable<string> Options { get; set; } = [];
}