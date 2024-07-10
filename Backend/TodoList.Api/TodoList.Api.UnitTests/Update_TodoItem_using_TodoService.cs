using TodoList.Api.Models;
using TodoList.Api.Services;
using Xunit;

namespace TodoList.Api.UnitTests;

//This test verifies the functionality of the Update method of the TodoService, not the database queries. In a 'real' application we would have integration tests for this purpose.
public class Update_TodoItem_using_TodoService
{
    [Fact]
    public async Task With_null_Id_throws_TodoItemIdentifierInvalidException()
    {
        //Arrange
        var item = new TodoItem
        {
            Id = null,
            Description = null,
            IsComplete = false
        };

        var service = Factory.CreateTodoService();

        //Act / Assert
        await Assert.ThrowsAsync<TodoItemIdentifierInvalidException>(async () => await service.Update(1, item));
    }

    [Fact]
    public async Task With_Id_different_to_the_request_path_Id_throws_TodoItemIdentifierInvalidException()
    {
        //Arrange
        var item = new TodoItem
        {
            Id = 1,
            Description = null,
            IsComplete = false
        };

        var service = Factory.CreateTodoService();

        //Act / Assert
        await Assert.ThrowsAsync<TodoItemIdentifierInvalidException>(async () => await service.Update(2, item));
    }

    [Fact]
    public async Task With_missing_item_throws_TodoItemNotFoundException()
    {
        //Arrange
        var item = new TodoItem
        {
            Id = 1,
            Description = "A todo item",
            IsComplete = false
        };

        var service = Factory.CreateTodoService(exists: false);

        //Act / Assert
        await Assert.ThrowsAsync<TodoItemNotFoundException>(async () => await service.Update(1, item));
    }

    [Fact]
    public async Task With_valid_item_succeeds()
    {
        //Arrange
        var item = new TodoItem
        {
            Id = 1,
            Description = "A todo item",
            IsComplete = false
        };

        var service = Factory.CreateTodoService();

        //Act
        await service.Update(1, item);

        //Assert
    }
}