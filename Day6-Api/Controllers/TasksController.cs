using Microsoft.AspNetCore.Mvc;
using Day6_Api.Models; // Подключаем наши модели
using System.Collections.Generic;
using System.Linq;

namespace Day6_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    // Теперь у нас список объектов, а не строк
    private static List<TaskItem> _tasks = new List<TaskItem>
    {
        new TaskItem { Id = 1, Title = "Купить хлеб", IsCompleted = false },
        new TaskItem { Id = 2, Title = "Помыть посуду", IsCompleted = true }
    };

    // GET: api/tasks
    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetAll()
    {
        return Ok(_tasks);
    }

    // GET: api/tasks/1
    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound(); // 404, если не нашли

        return Ok(task);
    }
}