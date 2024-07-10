using TodoList.Api.Models;

namespace TodoList.Api.Queries;

public interface IGetAllTodoItemsQuery : IQuery<TodoItem[]>
{
}