using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoCMS.Services;
using UmbracoCMS.ViewModels;

namespace UmbracoCMS.Controllers;

public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissionsService formSubmissionsService, EmailService emailService) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
{
  private readonly FormSubmissionsService _formSubmissionsService = formSubmissionsService;
  private readonly EmailService _emailService = emailService;

  public async Task<IActionResult> HandleCallbackForm(CallbackFormViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return CurrentUmbracoPage();
    }

    var result = _formSubmissionsService.SaveCallbackRequest(model);
    if (!result)
    {
      TempData["CallbackFormError"] = "Something went wrong while processing your request. Please try again later.";
      return RedirectToCurrentUmbracoPage();
    }

    await _emailService.SendEmailAsync(model.Email, "Thank you for contacting us!", $"Hi {model.Name},\n\nThank you for your request! We will get back to you soon.");

    TempData["CallbackFormSuccess"] = "Thank you for your request! We will get back to you soon.";
    return RedirectToCurrentUmbracoPage();
  }

  public async Task<IActionResult> HandleHelpFormAsync(HelpFormViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return CurrentUmbracoPage();
    }

    var result = _formSubmissionsService.SaveHelpRequest(model);
    if (!result)
    {
      TempData["HelpFormError"] = "Something went wrong while processing your request. Please try again later.";
      return RedirectToCurrentUmbracoPage();
    }

    await _emailService.SendEmailAsync(model.Email, "Thank you for contacting us!", $"Hi {model.Email},\n\nThank you for your request! We will get back to you soon.");

    TempData["HelpFormSuccess"] = "Thank you for your request! We will get back to you soon.";
    return RedirectToCurrentUmbracoPage();
  }

  public async Task<IActionResult> HandleQuestionFormAsync(QuestionFormViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return CurrentUmbracoPage();
    }

    var result = _formSubmissionsService.SaveQuestionRequest(model);
    if (!result)
    {
      TempData["QuestionFormError"] = "Something went wrong while processing your request. Please try again later.";
      return RedirectToCurrentUmbracoPage();
    }

    await _emailService.SendEmailAsync(model.QuestionEmail, "Thank you for contacting us!", $"Hi {model.QuestionName},\n\nThank you for your request! We will get back to you soon.");

    TempData["QuestionFormSuccess"] = "Thank you for your request! We will get back to you soon.";
    return RedirectToCurrentUmbracoPage();
  }
}