using TodoList.Api.Models;
using TodoList.Api.Services;
using Xunit;

namespace TodoList.Api.UnitTests;

//This test verifies the functionality of the GetOne method of the TodoService, not the database queries. In a 'real' application we would have integration tests for this purpose.
public class GetOne_TodoItem_using_TodoService
{
    [Fact]
    public async Task With_invalid_id_throws_TodoItemNotFoundException()
    {
        //Arrange
        var service = Factory.CreateTodoService();

        //Act / Assert
        await Assert.ThrowsAsync<TodoItemNotFoundException>(async () => await service.GetOne(1));
    }

    [Fact]
    public async Task With_valid_id_returns_notnull_item()
    {
        //Arrange
        var service = Factory.CreateTodoService(item: new TodoItem
        {
            Id = 1,
            Description = "A todo item",
            IsComplete = false
        });

        //Act
        var actual = await service.GetOne(1);

        //Assert
        Assert.NotNull(actual);
        
        //These are actually redundant, but eh. These properties represent values, not behaviour, so an integration test would be more appropriate.
        Assert.Equal(1, actual.Id);
        Assert.Equal("A todo item", actual.Description);
        Assert.False(actual.IsComplete);
    }
}