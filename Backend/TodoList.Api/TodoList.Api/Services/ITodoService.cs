using TodoList.Api.Models;

namespace TodoList.Api.Services;

public interface ITodoService
{
    Task<TodoItem> GetOne(long id);
    Task<TodoItem[]> GetAll();
    Task<long> Add(TodoItem item);
    Task Update(long id, TodoItem todoItem);
}