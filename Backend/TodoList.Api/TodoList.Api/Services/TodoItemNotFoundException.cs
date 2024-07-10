namespace TodoList.Api.Services;

//This exception is thrown when the item is not found in the database.
public class TodoItemNotFoundException : Exception, ITodoItemProblem
{
    //Obviously a 'real' application would have a more robust implementation for this, however this is enough to demonstrate the concept.
    public int Status => StatusCodes.Status404NotFound;
    public string Title => "Not Found";
    public string Detail => "The requested todo item can not be found.";
}