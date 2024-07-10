using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Models;
using TodoList.Api.Services;

namespace TodoList.Api.Controllers;

[Route("api/todoitems")]
[ApiController]
public class TodoItemsController(ITodoService todoService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(TodoItem[]), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await todoService.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TodoItem), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetOne(long id)
    {
        return Ok(await todoService.GetOne(id));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TodoItem), 204)]
    [ProducesResponseType(typeof(TodoItem), 204)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Put(long id, TodoItem todoItem)
    {
        await todoService.Update(id, todoItem);

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(typeof(TodoItem), 201)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post(TodoItem todoItem)
    {
        todoItem.Id = await todoService.Add(todoItem);

        return CreatedAtAction(nameof(GetOne), new
        {
            id = todoItem.Id
        }, todoItem);
    }
}