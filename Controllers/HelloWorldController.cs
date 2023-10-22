using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.DTOs;

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


        // hihihihihihihi


    }
    [HttpGet]
    [Route("testdb")]
    public IActionResult Get2()
    {
        var db = new ToDoDbContext();

        // LINQ
        var users = from x in db.User where x.Id == "1234567890123" select new { nationalId = x.Id };
        return Ok(users);

    }
}
