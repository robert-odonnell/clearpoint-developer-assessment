using System.Data;
using Dapper;
using TodoList.Api.Models;

namespace TodoList.Api.Commands;

public class AddTodoItemCommand(IDbConnection connection) : IAddTodoItemCommand
{
    public async Task<long> Execute(TodoItem todoItem) =>
        await connection.ExecuteScalarAsync<long>(Sql, new
        {
            todoItem.Description,
            todoItem.IsComplete
        });

    //I would normally externalise this resource by putting it in a resource assembly, text file, stored procedure or something else. This is so that if the query 
    //needed to be modified that didn't also require a change in interfaces, then the resource could be updated separate to the application deployment. This can be useful 
    //depending on the system requirements. But for this demonstration, lets just embed it here.
    private const string Sql =
        """
        DECLARE @Result TABLE ([Id] BIGINT);

        INSERT INTO [dbo].[TodoItems] ([Description], [IsComplete])
        OUTPUT INSERTED.[Id] INTO @Result
        VALUES (@Description, @IsComplete)

        SELECT TOP 1 [Id]
        FROM @Result
        """;
}