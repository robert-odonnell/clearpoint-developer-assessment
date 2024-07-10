namespace TodoList.Api.Services;

//This exception is thrown when there is a mismatch between the id and the item.
public class TodoItemIdentifierInvalidException : Exception, ITodoItemProblem
{
    //Obviously a 'real' application would have a more robust implementation for this, however this is enough to demonstrate the concept.
    public int Status => StatusCodes.Status400BadRequest;
    public string Title => "Bad Request";
    public string Detail => "The todo item and request path identifiers are either mismatched or invalid.";
}
