namespace TodoList.Api.Services;

//This exception is thrown when the item does not have a description.
public class TodoItemMissingDescriptionException : Exception, ITodoItemProblem
{
    //Obviously a 'real' application would have a more robust implementation for this, however this is enough to demonstrate the concept.
    public int Status => StatusCodes.Status400BadRequest;
    public string Title => "Bad Request";
    public string Detail => "The todo item does not have a valid description.";
}