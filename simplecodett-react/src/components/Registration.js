import React, {Component} from 'react';
import {Form, Button} from 'react-bootstrap';
import {Redirect} from 'react-router-dom';
import Cookies from 'js-cookie'

const REACT_APP_API = 'https:localhost:44359/api/'

class Registration extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            confPassword: '',
            isSubmitted: false
        }
        this.handleSubmit = this.handleSubmit.bind(this)
    }

    handleSubmit(event) {
        event.preventDefault()
        if (this.state.password !== this.state.confPassword) {
            alert("Пароли не совпадают")
        } else {
            const requestOptions = {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify({
                    "username": this.state.username,
                    "password": this.state.password,
                })
            };
            fetch(REACT_APP_API + 'signup', requestOptions)
                .then(response => response.json())
                .then(result => {
                    if (result.isSuccess) {
                        Cookies.set('__session', result.result.accessToken)
                        this.setState({isSubmitted: true})
                    }
                })
                .catch(error => console.log('Form submit error', error))
        }
    }

    render() {
        if (this.state.isSubmitted) {
            return <Redirect to='/employees'/>
        } else {
            return (
                <div className="container-md">
                    <h1>Registration page</h1>
                    <Form onSubmit={this.handleSubmit}>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control placeholder="Enter email"
                                          type="email"
                                          variable={this.state.username}
                                          onChange={(e) => this.setState({username: e.target.value})}
                                          required/>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control placeholder="Password"
                                          type="password"
                                          variable={this.state.password}
                                          onChange={(e) => this.setState({password: e.target.value})}
                                          required/>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Reenter password</Form.Label>
                            <Form.Control placeholder="Password"
                                          type="password"
                                          variable={this.state.confPassword}
                                          onChange={(e) => this.setState({confPassword: e.target.value})}
                                          required/>
                        </Form.Group>

                        <Button variant="primary" type="submit">
                            Submit
                        </Button>
                    </Form>
                </div>
            )
        }
    }
}

export default Registration