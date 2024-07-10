using TodoList.Api.Models;

namespace TodoList.Api.Commands;

public interface IUpdateTodoItemCommand : ICommand<TodoItem>
{
}