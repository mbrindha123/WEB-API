using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PMS_API;

[ApiController]
    [Route("[controller]/[Action]")]
public class DesignationController : ControllerBase
{
    private readonly ILogger _logger;
    public DesignationController(ILogger<DesignationController> logger)
    {
        _logger = logger;
    }
    IDesignationServices DesignationService = DesignationDataFactory.GetDesignationServiceObject();
    [HttpGet]
    public IActionResult ViewDesignations() //Getting the list of Designation
    {
        try
        {
             _logger.LogInformation("List of Designations......"); // Passing Information to log
            return Ok(DesignationService.ViewDesignations());
           
        }
         catch (Exception exception) // Handling Exception
        {
             _logger.LogError($"DesignationController:ViewDesignations()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
           
        }
    }

}