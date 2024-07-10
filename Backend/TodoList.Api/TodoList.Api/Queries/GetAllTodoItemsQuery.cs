using System.Data;
using Dapper;
using TodoList.Api.Models;

namespace TodoList.Api.Queries;

public class GetAllTodoItemsQuery(IDbConnection connection) : IGetAllTodoItemsQuery
{
    public async Task<TodoItem[]> Execute() => 
        (await connection.QueryAsync<TodoItem>(Sql)).ToArray();

    //I would normally externalise this resource by putting it in a resource assembly, text file, stored procedure or something else. This is so that if the query 
    //needed to be modified that didn't also require a change in interfaces, then the resource could be updated separate to the application deployment. This can be useful 
    //depending on the system requirements. But for this demonstration, lets just embed it here.
    private const string Sql = """
                               SELECT [Id], [Description], [IsComplete]
                               FROM   [dbo].[TodoItems]
                               WHERE  [IsComplete] = 0
                               """;
}