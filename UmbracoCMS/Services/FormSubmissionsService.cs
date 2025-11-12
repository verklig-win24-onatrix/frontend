using Umbraco.Cms.Core.Services;
using UmbracoCMS.ViewModels;

namespace UmbracoCMS.Services;

public class FormSubmissionsService(IContentService contentService)
{
  private readonly IContentService _contentService = contentService;

  public bool SaveCallbackRequest(CallbackFormViewModel model)
  {
    try
    {
      var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "callbackSubmissions");
      if (container == null)
      {
        return false;
      }

      var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
      var request = _contentService.Create(requestName, container, "callbackRequest");

      request.SetValue("callbackRequestName", model.Name);
      request.SetValue("callbackRequestEmail", model.Email);
      request.SetValue("callbackRequestPhone", model.Phone);
      request.SetValue("callbackRequestOption", model.SelectedOption);

      var saveResult = _contentService.Save(request);
      return saveResult.Success;
    }
    catch
    {
      return false;
    }
  }

  public bool SaveHelpRequest(HelpFormViewModel model)
  {
    try
    {
      var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "helpSubmissions");
      if (container == null)
      {
        return false;
      }

      var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Email}";
      var request = _contentService.Create(requestName, container, "helpRequest");

      request.SetValue("helpRequestEmail", model.Email);

      var saveResult = _contentService.Save(request);
      return saveResult.Success;
    }
    catch
    {
      return false;
    }
  }

  public bool SaveQuestionRequest(QuestionFormViewModel model)
  {
    try
    {
      var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "questionSubmissions");
      if (container == null)
      {
        return false;
      }

      var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.QuestionName}";
      var request = _contentService.Create(requestName, container, "questionRequest");

      request.SetValue("questionRequestName", model.QuestionName);
      request.SetValue("questionRequestEmail", model.QuestionEmail);
      request.SetValue("questionRequestText", model.Question);

      var saveResult = _contentService.Save(request);
      return saveResult.Success;
    }
    catch
    {
      return false;
    }
  }
}