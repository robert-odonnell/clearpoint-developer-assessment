using TodoList.Api.Commands;
using TodoList.Api.Models;
using TodoList.Api.Queries;

namespace TodoList.Api.Services;

//While not strictly CQRS, the same principles apply. Commands are used to change state and queries return data. Nothing enforces these rules, but it is
//good practice to keep commands and queries separate. This helps to reason about the code, especially when an application is large and complex. Overkill for
//this scenario, but that's not the point though.

//The service orchestrates the commands and queries in order to affect the outcome desired.
public class TodoService(
    //These would normally be invoked via some other infrastructure, but is out of scope for this purpose.
    IGetOneTodoItemQuery getOne, 
    IGetAllTodoItemsQuery getAll, 
    ITodoItemExistsQuery exists, 
    ITodoItemUniqueQuery unique, 
    IAddTodoItemCommand add, 
    IUpdateTodoItemCommand update) : ITodoService
{
    public async Task<TodoItem> GetOne(long id) =>
        //Try and get the requested item from the database.
        await getOne.Execute(id) ?? throw new TodoItemNotFoundException();

    public async Task<TodoItem[]> GetAll() =>
        //Let's just get all the incomplete items from the database. If this were a 'real' application we should be considering paging.
        await getAll.Execute();

    public async Task<long> Add(TodoItem item)
    {
        //Ensure that the item was supplied without an id. 
        if (item.Id != null)
        {
            throw new TodoItemIdentifierInvalidException();
        }

        //Ensure that the item has a description.
        if (string.IsNullOrEmpty(item.Description))
        {
            throw new TodoItemMissingDescriptionException();
        }

        //Ensure that the item description is unique among all incomplete items in the database.
        if (!await unique.Execute(item.Description))
        {
            throw new TodoItemAlreadyExistsException();
        }

        //Go ahead and the item to the database.
        return await add.Execute(item);
    }

    public async Task Update(long id, TodoItem todoItem)
    {
        //Ensure that the item was supplied an id, and that it matches the one we're being asked to update. 
        if (todoItem.Id == null || id != todoItem.Id)
        {
            throw new TodoItemIdentifierInvalidException();
        }

        //Ensure that the item has a description.
        if (string.IsNullOrEmpty(todoItem.Description))
        {
            throw new TodoItemMissingDescriptionException();
        }  

        //Ensure that the item with the provided id exists in the database.
        if (!await exists.Execute(id))
        {
            throw new TodoItemNotFoundException();
        }

        //Save the item to the database.
        await update.Execute(todoItem);
    }
}