using Microsoft.AspNetCore.Mvc;
using Writers.API.Models;
using Writers.API.Services;

namespace Writers.API.Controllers;

public class WritersController : ControllerBase
{
    private readonly WriterService _writerService;

    public WritersController(WriterService writerService)
    {
        _writerService = writerService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
       var writer = _writerService.GetAll();
       return Ok(writer);
    }

    [HttpGet]
    public IActionResult GetWriter(int id)
    {
        var writer = _writerService.Get(id);
        if (writer == null)
        {
            return NotFound();
        }

        return Ok(writer);
    }

    [HttpPost]
    public IActionResult AddWriter([FromBody] Writer writer)
    {
        var res = _writerService.PostWriter(writer);
        return Created($"/get/{res.Id}", res);
    }
}