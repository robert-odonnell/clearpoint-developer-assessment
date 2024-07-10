using TodoList.Api.Models;

namespace TodoList.Api.Queries;

public interface IGetOneTodoItemQuery : IQuery<long, TodoItem?>
{
}