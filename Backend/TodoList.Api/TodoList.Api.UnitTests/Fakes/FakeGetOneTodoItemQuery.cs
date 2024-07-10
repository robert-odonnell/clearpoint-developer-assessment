using TodoList.Api.Models;
using TodoList.Api.Queries;

namespace TodoList.Api.UnitTests.Fakes;

//Provide a fake implementation for the TodoService, this could also be achieved using mocks using whatever mocking library is preferred.
public class FakeGetOneTodoItemQuery(TodoItem? item = null) : IGetOneTodoItemQuery
{
    public Task<TodoItem?> Execute(long request) => Task.FromResult(item);
}