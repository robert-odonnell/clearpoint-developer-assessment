namespace TodoList.Api.Queries;

public interface IQuery<in TRequest, TResponse>
{
    Task<TResponse> Execute(TRequest request);
}