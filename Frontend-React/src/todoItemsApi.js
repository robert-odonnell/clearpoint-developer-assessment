import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const todoItemsApi = createApi({
    reducerPath: 'todoItems',
    baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:5001/api' }),
    tagTypes: ['TodoItem'],
    endpoints: (builder) => ({
        getAllTodoItems: builder.query({
            query: () => '/todoitems',
            providesTags: ['TodoItem'],
        }),
        getOneTodoItem: builder.query({
            query: (id) => `todoitems/${id}`,
            providesTags: ['TodoItem'],
        }),
        addTodoItem: builder.mutation({
            query: (todoItem) => ({
                url: '/todoitems',
                method: 'POST',
                body: todoItem,
                headers: {
                    'Content-type': 'application/json; charset=UTF-8',
                },
            }),
            invalidatesTags: ['TodoItem'],
        }),
        updateTodoItem: builder.mutation({
            query: (todoItem) => ({
                url: `/todoitems/${todoItem.id}`,
                method: 'PUT',
                body: todoItem,
                headers: {
                    'Content-type': 'application/json; charset=UTF-8',
                },
            }),
            invalidatesTags: ['TodoItem'],
        }),
    }), 
})

export const {
    useGetAllTodoItemsQuery, 
    useGetOneTodoItemQuery, 
    useAddTodoItemMutation, 
    useUpdateTodoItemMutation
} = todoItemsApi