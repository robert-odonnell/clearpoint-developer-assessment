import './App.css'
import { Button } from 'react-bootstrap'
import React from 'react'
import { useUpdateTodoItemMutation } from './todoItemsApi'

const TodoItem = ({ todoItem }) => {
  const [updateTodoItem] = useUpdateTodoItemMutation()

  const onMarkAsCompleteClicked = async () =>{
    try {
      await updateTodoItem({ id: todoItem.id, description: todoItem.description, isComplete: true }).unwrap()
    } catch (error) {
      console.error(error)
    }
  }

  return (
    <tr>
      <td>{todoItem.id}</td>
      <td>{todoItem.description}</td>
      <td>
        <Button variant="warning" size="sm" onClick={() => onMarkAsCompleteClicked(todoItem)}>
          Mark as complete
        </Button>
      </td>
    </tr>    
  )
}

export default TodoItem
