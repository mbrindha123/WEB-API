using Microsoft.AspNetCore.Mvc;
using PROFILE.Models;
using PROFILE.Services;
using System.Net;

namespace PROFILE.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CollegeController : ControllerBase
{
    private readonly ILogger _logger;
    public CollegeController(ILogger<CollegeController> logger)
    {
        _logger = logger;
    }
    ICollegeServices collegeService = DataFactory.CollegeDataFactory.GetCollegeServiceObject();

    [HttpPost]
    public IActionResult CreateNewCollege(string collegeName)
    {
        if (collegeName == null) 
            return BadRequest("College name is required");

        try
        {
            return collegeService.CreateCollege(collegeName) ? Ok("College Added Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("College Service : CreateCollege throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    [HttpPost]
    public IActionResult RemoveCollege(int collegeId)
    {
        if (collegeId == 0) return BadRequest("College Id is not provided");

        try
        {
            return collegeService.RemoveCollege(collegeId) ? Ok("College Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("College Service : RemoveCollege throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewColleges()
    {
        try
        {
            return Ok(collegeService.ViewColleges());
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching roles ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

}