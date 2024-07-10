namespace TodoList.Api.Commands;

public interface ICommand<in TRequest>
{
    Task Execute(TRequest request);
}