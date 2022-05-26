using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PMS_API;

[ApiController]
    [Route("[controller]/[Action]")]
public class DomainController : ControllerBase
{
    private readonly ILogger _logger;
    public DomainController(ILogger<DomainController> logger)
    {
        _logger = logger;
    }
    IDomainServices DomainService = DomainDataFactory.GetDomainServiceObject();
    [HttpGet]
    public IActionResult ViewDomains() //Getting the list of Domains
    {
        try
        {
             _logger.LogInformation("List of Domains......"); //Passing Information to log
            return Ok(DomainService.ViewDomains());
           
        }
        catch (Exception exception) // Handling Exception
        {
             _logger.LogError($"DomainController:ViewDomains()-{exception.Message}{exception.StackTrace}");
            return BadRequest(exception.Message);
           
        }
    }

}