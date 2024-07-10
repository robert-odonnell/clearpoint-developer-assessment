using TodoList.Api.Queries;

namespace TodoList.Api.UnitTests.Fakes;

//Provide a fake implementation for the TodoService, this could also be achieved using mocks using whatever mocking library is preferred.
public class FakeTodoItemExistsQuery(bool result = true) : ITodoItemExistsQuery
{
    public Task<bool> Execute(long request) => Task.FromResult(result);
}