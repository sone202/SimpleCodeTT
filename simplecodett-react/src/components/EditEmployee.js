import React, {Component} from 'react';
import {Link, Redirect} from 'react-router-dom';
import {Button, Form} from 'react-bootstrap';
import Cookies from 'js-cookie'

const REACT_APP_API = 'https:localhost:44359/api/'

class EditEmployee extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id: props.id,
            name: props.name,
            email: props.email,
            birthday: props.birthday,
            salary: props.salary,
            isSubmitted: false
        }
        this.handleSubmit=this.handleSubmit.bind(this)
        this.authString = 'Bearer ' + Cookies.get('__session')
    }

    handleSubmit(event) {
        event.preventDefault()
        if (window.confirm('Are you sure you wish to edit this item?')) {
            const requestOptions = {
                method: 'PATCH',
                headers: {'Content-Type': 'application/json',
                    'Authorization': this.authString},
                body: JSON.stringify({
                    "id": this.state.id,
                    "name": this.state.name,
                    "email": this.state.email,
                    "birthday": this.state.birthday + "T00:00:00",
                    "salary": Number(this.state.salary),
                    "lastModifiedDate": "1111-11-11T00:00:00"
                })
            };
            fetch(REACT_APP_API + 'employees/' + this.state.id, requestOptions)
                .then(this.setState({isSubmitted: true}))
                .catch(error => console.log('Form submit error', error))
        }
    }

    componentDidMount(props) {
        let emp = this.props.location.state
        this.setState({
            id: emp.id,
            name: emp.name,
            email: emp.email,
            birthday: emp.birthday.split('T')[0],
            salary: emp.salary
        })
    }

    render() {
        if (this.state.isSubmitted) {
            return <Redirect to='/employees' replace/>
        } else {
            return (
                <div className="container">
                    <h1>Edit employee data</h1>
                    <Form onSubmit={this.handleSubmit}>
                        {/*name*/}
                        <Form.Group className="mb-3" controlId="name">
                            <Form.Label>Name</Form.Label>
                            <Form.Control placeholder="Ex. John Poland"
                                          required
                                          type="text"
                                          value={this.state.name}
                                          onChange={(e) => this.setState({name: e.target.value})}
                            />
                        </Form.Group>

                        {/*email*/}
                        <Form.Group className="mb-3" controlId="email">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control placeholder="example@mail.com"
                                          required
                                          type="email"
                                          value={this.state.email}
                                          onChange={(e) => this.setState({email: e.target.value})}
                            />
                        </Form.Group>

                        {/*birthday*/}
                        <Form.Group className="mb-3" controlId="birthday">
                            <Form.Label>Birthday</Form.Label>
                            <Form.Control required
                                          type="date"
                                          value={this.state.birthday}
                                          onChange={(e) => this.setState({birthday: e.target.value})}
                            />
                        </Form.Group>

                        {/*salary*/}
                        <Form.Group className="mb-3" controlId="salary">
                            <Form.Label>Salary</Form.Label>
                            <Form.Control placeholder="0.0000"
                                          required
                                          type="number"
                                          step={0.0001}
                                          value={this.state.salary}
                                          onChange={(e) => this.setState({salary: e.target.value})}
                            />
                        </Form.Group>

                        {/*buttons*/}
                        <div className="mt-3">

                            <Button variant='primary' type="submit">
                                Submit</Button>

                            {' '}
                            <Link to='/employees' replace>
                                <Button variant='danger'>
                                    Cancel</Button>
                            </Link>
                        </div>
                    </Form>
                </div>
            );
        }
    }
}

export default EditEmployee

