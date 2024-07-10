using System.Data;
using Dapper;

namespace TodoList.Api.Queries;

public class TodoItemUniqueQuery(IDbConnection connection) : ITodoItemUniqueQuery
{
    public async Task<bool> Execute(string description) =>
        await connection.QuerySingleAsync<long>(Sql, new
        {
            Description = description
        }) == 0;

    //I would normally externalise this resource by putting it in a resource assembly, text file, stored procedure or something else. This is so that if the query 
    //needed to be modified that didn't also require a change in interfaces, then the resource could be updated separate to the application deployment. This can be useful 
    //depending on the system requirements. But for this demonstration, lets just embed it here.
    private const string Sql = """
                               SELECT COUNT(1) [Count]
                               FROM   [dbo].[TodoItems]
                               WHERE  [Description] = @Description AND [IsComplete] = 0
                               """;
}