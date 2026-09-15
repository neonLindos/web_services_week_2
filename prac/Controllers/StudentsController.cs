using Microsoft.AspNetCore.Mvc;
using StudentsApiM2.Models;

namespace StudentsApiM2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private static List<Student> students = new()
    {
        new Student { Id = 1, Name = "Alex", Group = "SE-301" },
        new Student { Id = 2, Name = "Anna", Group = "SE-302" },
        new Student { Id = 3, Name = "Max", Group = "SE-301" }
    };

    // GET /api/students
    [HttpGet]
    public ActionResult<List<Student>> GetAll()
    {
        return Ok(students);
    }

    // GET /api/students/{id}
    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    // POST /api/students
    [HttpPost]
    public ActionResult<Student> Create(Student student)
    {
        students.Add(student);

        return Ok(student);
    }
}
