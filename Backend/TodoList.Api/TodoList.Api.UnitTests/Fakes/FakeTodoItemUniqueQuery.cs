using TodoList.Api.Queries;

namespace TodoList.Api.UnitTests.Fakes;

//Provide a fake implementation for the TodoService, this could also be achieved using mocks using whatever mocking library is preferred.
public class FakeTodoItemUniqueQuery(bool result = true) : ITodoItemUniqueQuery
{
    public Task<bool> Execute(string request) => Task.FromResult(result);
}