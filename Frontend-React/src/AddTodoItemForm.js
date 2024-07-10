import { Button, Container, Row, Col, Form, Stack } from 'react-bootstrap'
import React, { useState } from 'react'
import { useAddTodoItemMutation } from './todoItemsApi'

const AddTodoItemForm = () => {
  const [description, setDescription] = useState('')

  const [addTodoItem, { isLoading }] = useAddTodoItemMutation()

  const onDescriptionChanged = e => setDescription(e.target.value)
  
  const canSave = [description].every(Boolean) && !isLoading

  const onAddItemClicked = async () => {
    if (canSave) {
      try {
        await addTodoItem({ description }).unwrap()
        setDescription('')
      } catch (error) {
        console.error(error)
      }
    }
  }

  const onClearClicked = () => {
    setDescription('')
  }

   return (
    <Container>
      <h1>Add Item</h1>
      <Form.Group as={Row} className="mb-3" controlId="formAddTodoItem">
        <Form.Label column sm="2">
          Description
        </Form.Label>
        <Col md="6">
          <Form.Control
            type="text"
            placeholder="Enter description..."
            value={description}
            onChange={onDescriptionChanged}
          />
        </Col>
      </Form.Group>
      <Form.Group as={Row} className="mb-3 offset-md-2" controlId="formAddTodoItem">
        <Stack direction="horizontal" gap={2}>
          <Button variant="primary" onClick={() => onAddItemClicked()}>
            Add Item
          </Button>
          <Button variant="secondary" onClick={() => onClearClicked()}>
            Clear
          </Button>
        </Stack>
      </Form.Group>
    </Container>
  )
}

export default AddTodoItemForm
