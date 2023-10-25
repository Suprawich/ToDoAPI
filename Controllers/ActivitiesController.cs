using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ToDoAPI.Models;
using ToDoAPI.DTOs;

namespace ToDoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivitiesController : ControllerBase
{

    private readonly ILogger<ActivitiesController> _logger;

    public ActivitiesController(ILogger<ActivitiesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    [Authorize(Roles = "user")]
    public IActionResult Get(uint Id)
    {
        
        var db = new ToDoDbContext();
        var activity = from a in db.Activity /*where a.Id == Id*/ select a;
        // new {
        //     id = a.Id,
        //     name = a.Name,
        //     when = a.When
        // }).FirstOrDefault();

        if (activity == null) return NotFound();
        return Ok(activity);
    }
    
    [HttpPost]
    [Authorize(Roles = "user")]
    public IActionResult Post([FromBody] DTOs.Activity data)
    {
        var db = new ToDoDbContext();
        
        var a = new Models.Activity(); //new record
        a.Name = data.Name;
        a.When = data.When;
        db.Activity.Add(a);
        db.SaveChanges();

        return Ok(new {id = a.Id}); //sent Id to frontend
    }

    [HttpPut]
    [Route("{Id}")]
    [Authorize(Roles = "user")]
    public IActionResult Put(uint Id, [FromBody] DTOs.Activity data)
    {
        var db = new ToDoDbContext();
        
        var a = db.Activity.Find(Id);
        if (a == null) return NotFound();

        a.Name = data.Name;
        a.When = data.When;
        db.SaveChanges();

        return Ok();
    }
    
    [Route("{Id}")]
    [HttpDelete]
    [Authorize(Roles = "user")]
    public IActionResult Delete(uint Id)
    {
        var db = new ToDoDbContext();
        
        var a = db.Activity.Find(Id);
        if (a == null) return NotFound();

        db.Activity.Remove(a);
        db.SaveChanges();

        return Ok();
    }
}
