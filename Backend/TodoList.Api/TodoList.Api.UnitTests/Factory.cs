using TodoList.Api.Models;
using TodoList.Api.Services;
using TodoList.Api.UnitTests.Fakes;

namespace TodoList.Api.UnitTests;

public static class Factory
{
    //Factory method for TodoService supporting the scenarios these tests.
    public static TodoService CreateTodoService(bool exists = true, bool unique = true, long id = 1, TodoItem? item = null)
    {
        return new TodoService(
            new FakeGetOneTodoItemQuery(item),
            new FakeGetAllTodoItemsQuery(),
            new FakeTodoItemExistsQuery(exists),
            new FakeTodoItemUniqueQuery(unique),
            new FakeAddTodoItemCommand(id),
            new FakeUpdateTodoItemCommand());
    }
}