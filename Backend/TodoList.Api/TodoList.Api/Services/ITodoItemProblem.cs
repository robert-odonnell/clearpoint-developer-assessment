namespace TodoList.Api.Services;

public interface ITodoItemProblem
{
    int Status { get; }
    string Title { get; }
    string Detail { get; }
}