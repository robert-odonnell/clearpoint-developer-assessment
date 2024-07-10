import './App.css'
import { Table } from 'react-bootstrap'
import React  from 'react'
import { useGetAllTodoItemsQuery } from './todoItemsApi'
import TodoItem from './TodoItem'

const TodoItemsList = () => {
  const {
    data: todoItems,
    isLoading,
    isSuccess,
    isError,
    error
  } = useGetAllTodoItemsQuery()

  if (isLoading) {
    return (
      <div>Loading...</div>
    )
  } else if (isSuccess) {
    return (
      <>
      <h1>
        Showing {todoItems.length} Item(s){' '}
      </h1>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Id</th>
            <th>Description</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {todoItems.map(todoItem => (
            <TodoItem key={todoItem.id} todoItem={todoItem} />
          ))}
        </tbody>
      </Table>
    </>)
  } else if (isError) {
    return (
      <div>{error.toString()}</div>
    )
  }
  return null
}

export default TodoItemsList
