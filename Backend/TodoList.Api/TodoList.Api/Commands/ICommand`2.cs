namespace TodoList.Api.Commands;

public interface ICommand<in TRequest, TResponse>
{
    Task<TResponse> Execute(TRequest request);
}