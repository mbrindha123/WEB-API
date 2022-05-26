using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PMS_API;

[ApiController]
    [Route("[controller]/[Action]")]
public class TechnologyController : ControllerBase
{
    private readonly ILogger _logger;
    public TechnologyController(ILogger<TechnologyController> logger)
    {
        _logger = logger;
    }
    ITechnologyServices technologyService = TechnologyDataFactory.GetTechnologyServiceObject();
    [HttpGet]
    public IActionResult ViewTechnologies() //Getting the list of Technologies
    {
        try
        {
             _logger.LogInformation("List of Technologies......"); //Passing the Information to log
            return Ok(technologyService.ViewTechnologies());
           
        }
        catch (Exception exception) // Handling Exception
        {
             _logger.LogError($"TechnologyController:ViewTechnologies()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
           
        }
    }

}