using TodoList.Api.Models;

namespace TodoList.Api.Commands;

public interface IAddTodoItemCommand : ICommand<TodoItem, long>
{
}
