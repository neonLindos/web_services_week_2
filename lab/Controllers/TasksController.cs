using Microsoft.AspNetCore.Mvc;
using TasksApi.Models;

namespace TasksApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> tasks = new()
    {
        new TaskItem
        {
            Id = 1,
            Title = "Learn ASP.NET Core",
            Description = "Пройти модуль 02",
            IsCompleted = false
        },

        new TaskItem
        {
            Id = 2,
            Title = "Setup Swagger",
            Description = "Проверить endpoint'ы через Swagger UI",
            IsCompleted = true
        }
    };

    // GET /api/tasks
    [HttpGet]
    public ActionResult<List<TaskItem>> GetAll()
    {
        return Ok(tasks);
    }

    // GET /api/tasks/{id}
    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    // POST /api/tasks
    [HttpPost]
    public ActionResult<TaskItem> Create(TaskItem task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
        {
            return BadRequest("Title обязателен.");
        }

        task.Id = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;

        tasks.Add(task);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    // PUT /api/tasks/{id}
    [HttpPut("{id}")]
    public ActionResult<TaskItem> Update(int id, TaskItem updated)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(updated.Title))
        {
            return BadRequest("Title обязателен.");
        }

        task.Title = updated.Title;
        task.Description = updated.Description;
        task.IsCompleted = updated.IsCompleted;

        return Ok(task);
    }

    // DELETE /api/tasks/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return NotFound();
        }

        tasks.Remove(task);

        return Ok();
    }
}
