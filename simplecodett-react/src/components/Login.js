import React, {Component} from 'react';
import {Form, Button} from "react-bootstrap";
import {Link, Redirect} from 'react-router-dom';
import Cookies from 'js-cookie'

const REACT_APP_API = 'https:localhost:44359/api/'

class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            isSubmitted: false
        }
        this.handleSubmit=this.handleSubmit.bind(this)
    }

    handleSubmit(event) {
        event.preventDefault()
        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "username": this.state.username,
                "password": this.state.password,
            })
        };
        fetch(REACT_APP_API + 'signin', requestOptions)
            .then(response => response.json())
            .then(result => {
                if (result.isSuccess) {
                    Cookies.set('__session', result.result.accessToken)
                    this.setState({isSubmitted: true})
                } else {
                    alert("Неправильный логин или пароль")
                }
            })
            .catch(error => console.log('Form submit error', error))
    }

    render() {
        if (this.state.isSubmitted) {
            return <Redirect to='employees' replace/>
        } else {
            return (
                <div className="container-md">
                    <h1>Login page</h1>
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
                        <Button variant="primary" type="submit">
                            Sign in
                        </Button>
                        {' '}
                        <Link to='signup'>
                            <Button variant="secondary">
                                Sign up
                            </Button>
                        </Link>
                    </Form>
                </div>
            )
        }
    }
}

export default Login