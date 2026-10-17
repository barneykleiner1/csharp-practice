using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Day6_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static List<string> _tasks = new List<string>
    {
        "Купить хлеб",
        "Помыть посуду",
        "Сделать зарядку"
    };

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetAll()
    {
        return Ok(_tasks);
    }
}