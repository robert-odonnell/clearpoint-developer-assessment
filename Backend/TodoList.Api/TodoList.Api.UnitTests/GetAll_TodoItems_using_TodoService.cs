using Xunit;

namespace TodoList.Api.UnitTests;

//This test verifies the functionality of the GetAll method of the TodoService, not the database queries. In a 'real' application we would have integration tests for this purpose.
public class GetAll_TodoItems_using_TodoService
{
    //This test only exists to drive the development of the GetAll method using Test Driven Development. I would normally delete this as it is a pass through
    //to the database only. That is, there is no behaviour to test in this method. 
    [Fact]
    public async Task Succeeds()
    {
        //Arrange
        var service = Factory.CreateTodoService();

        //Act
        await service.GetAll();

        //Assert
    }
}