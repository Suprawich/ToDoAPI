using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Get()
    {
        return Ok();

    }
    // [HttpGet]
    // [Route("testdb")]
    // public IActionResult Get()
    // {
    //     var db = new ToDoDbContext();
    //     return Ok();

    // }
}
