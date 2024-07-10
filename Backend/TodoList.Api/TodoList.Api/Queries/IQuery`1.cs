namespace TodoList.Api.Queries;

public interface IQuery<TResponse>
{
    Task<TResponse> Execute();
}