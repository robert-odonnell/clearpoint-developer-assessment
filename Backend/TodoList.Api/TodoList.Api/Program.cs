using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using TodoList.Api.Commands;
using TodoList.Api.Infrastructure;
using TodoList.Api.Queries;
using TodoList.Api.Services;

var webAppBuilder = WebApplication.CreateBuilder(args);

var configuration = webAppBuilder.Configuration;

//Ready

var services = webAppBuilder.Services;

services.AddScoped<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("TodoItems")));

services.AddScoped<IAddTodoItemCommand, AddTodoItemCommand>();
services.AddScoped<IUpdateTodoItemCommand, UpdateTodoItemCommand>();

services.AddScoped<IGetAllTodoItemsQuery, GetAllTodoItemsQuery>();
services.AddScoped<IGetOneTodoItemQuery, GetOneTodoItemQuery>();
services.AddScoped<ITodoItemExistsQuery, TodoItemExistsQuery>();
services.AddScoped<ITodoItemUniqueQuery, TodoItemUniqueQuery>();

services.AddScoped<ITodoService, TodoService>();

services.AddCors(options =>
{
    //Not a very good CORS policy...
    options.AddPolicy("AllowAllHeaders", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

services.AddControllers();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TodoList.Api", 
        Version = "v1"
    });
});

//Steady

var app = webAppBuilder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList.Api v1"));
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseCors("AllowAllHeaders");
app.UseAuthorization();
app.MapControllers();

//Go!

app.Run();