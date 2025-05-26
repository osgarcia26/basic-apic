using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository _repository;

    public UserController(UserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repository.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = _repository.Get(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = _repository.Add(user);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return _repository.Update(id, user) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) =>
        _repository.Delete(id) ? NoContent() : NotFound();
}
