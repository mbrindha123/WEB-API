using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace PMS_API;

[ApiController]
    [Route("[controller]/[Action]")]
public class CollegeController : ControllerBase
{
    private readonly ILogger _logger;
    public CollegeController(ILogger<CollegeController> logger)
    {
        _logger = logger;
    }
    ICollegeServices collegeService = CollegeDataFactory.GetCollegeServiceObject(); //Calling Object
    [HttpGet]
    public IActionResult ViewColleges() //Getting The List of Colleges
    {
        try
        {
             _logger.LogInformation("List of Colleges......"); //Passing Information to log
            return Ok(collegeService.ViewColleges());
           
        }
        catch (Exception exception) // Handling Exception
        {
             _logger.LogError($"CollegeController:ViewColleges()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
           
        }
    }

}