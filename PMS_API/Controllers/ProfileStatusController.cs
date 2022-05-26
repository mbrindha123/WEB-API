using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PMS_API;

[ApiController]
    [Route("[controller]/[Action]")]
public class ProfileStatusController : ControllerBase
{
    private readonly ILogger _logger;
   public ProfileStatusController(ILogger<ProfileStatusController> logger)
    {
        _logger = logger;
    }
     IProfileStatusServices ProfileStatusService = ProfileStatusDataFactory.GetProfileStatusServiceObject();
    [HttpGet]
    public IActionResult ViewProfileStatuss() //Getting the list of ProfileStatuss
    {
        try
        {
             _logger.LogInformation("List of ProfileStatuss......"); //Passing Information to log
            return Ok(ProfileStatusService.ViewProfileStatuss());
           
        }
        catch (Exception exception) // Handling Exception
        {
              _logger.LogError($"ProfileStatusController:ViewProfileStatuss()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
           
        }
    }

}