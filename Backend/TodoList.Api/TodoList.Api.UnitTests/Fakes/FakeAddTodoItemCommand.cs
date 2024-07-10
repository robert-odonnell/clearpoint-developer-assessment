using TodoList.Api.Commands;
using TodoList.Api.Models;

namespace TodoList.Api.UnitTests.Fakes;

//Provide a fake implementation for the TodoService, this could also be achieved using mocks using whatever mocking library is preferred.
public class FakeAddTodoItemCommand(long id = 0) : IAddTodoItemCommand
{
    public Task<long> Execute(TodoItem request) => Task.FromResult(id);
}