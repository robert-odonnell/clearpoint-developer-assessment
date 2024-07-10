import './App.css'
import { Image, Container, Row, Col } from 'react-bootstrap'
import React from 'react'
import AddTodoItemForm from './AddTodoItemForm'
import TodoItemsList from './TodoItemsList'

const App = () => {
  return (
    <div className="App">
      <Container>
        <Row>
          <Col>
            <Image src="clearPointLogo.png" fluid rounded />
          </Col>
        </Row>
        <Row>
          <Col><AddTodoItemForm /></Col>
        </Row>
        <br />
        <Row>
          <Col><TodoItemsList /></Col>
        </Row>
      </Container>
      <footer className="page-footer font-small teal pt-4">
        <div className="footer-copyright text-center py-3">
          © 2021 Copyright:
          <a href="https://clearpoint.digital" target="_blank" rel="noreferrer">
            clearpoint.digital
          </a>
        </div>
      </footer>
    </div>
  )
}

export default App
