using TodoList.Api.Models;
using TodoList.Api.Services;
using Xunit;

namespace TodoList.Api.UnitTests;

//This test verifies the functionality of the Add method of the TodoService, not the database queries. In a 'real' application we would have integration tests for this purpose.
public class Add_TodoItem_using_TodoService
{
    [Fact]
    public async Task With_notnull_Id_throws_TodoItemIdentifierInvalidException()
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
        await Assert.ThrowsAsync<TodoItemIdentifierInvalidException>(async () => await service.Add(item));
    }

    [Fact]
    public async Task With_null_Description_throws_TodoItemMissingDescriptionException()
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
        await Assert.ThrowsAsync<TodoItemMissingDescriptionException>(async () => await service.Add(item));
    }

    [Fact]
    public async Task With_empty_Description_throws_TodoItemMissingDescriptionException()
    {
        //Arrange
        var item = new TodoItem
        {
            Id = null,
            Description = string.Empty,
            IsComplete = false
        };

        var service = Factory.CreateTodoService();

        //Act / Assert
        await Assert.ThrowsAsync<TodoItemMissingDescriptionException>(async () => await service.Add(item));
    }

    [Fact]
    public async Task With_non_unique_Description_throws_TodoItemAlreadyExistsException()
    {
        //Arrange
        var item = new TodoItem
        {
            Id = null,
            Description = "NotUnique",
            IsComplete = false
        };

        var service = Factory.CreateTodoService(unique: false);

        //Act / Assert
        await Assert.ThrowsAsync<TodoItemAlreadyExistsException>(async () => await service.Add(item));
    }

    [Fact]
    public async Task With_valid_item_returns_the_an_Id_for_the_item()
    {
        //Arrange
        var item = new TodoItem
        {
            Id = null,
            Description = "A todo item",
            IsComplete = false
        };


        var service = Factory.CreateTodoService(id: 1);

        //Act
        var id = await service.Add(item);

        //Assert
        Assert.Equal(1, id);
    }
}