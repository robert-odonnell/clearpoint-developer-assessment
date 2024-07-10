namespace TodoList.Api.Services;

//This exception is thrown when an item with the supplied description is already present in the database.
public class TodoItemAlreadyExistsException : Exception, ITodoItemProblem
{
    //Obviously a 'real' application would have a more robust implementation for this, however this is enough to demonstrate the concept.
    public int Status => StatusCodes.Status400BadRequest;
    public string Title => "Bad Request";
    public string Detail => "The todo item already exists.";
}