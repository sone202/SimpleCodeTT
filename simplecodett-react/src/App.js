import './styles/App.css';
import React, {Component} from 'react'

import Employee from './components/Employee';
import EditEmployee from './components/EditEmployee';
import Login from "./components/Login";
import Registration from "./components/Registration";
import AddEmployee from './components/AddEmployee';

import {BrowserRouter as Router, Route, Redirect, Link} from 'react-router-dom';
import {Button, Container, Col, Navbar, Nav} from 'react-bootstrap'
import Cookies from 'js-cookie'

class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isAuthorized: typeof Cookies.get('__session') != 'undefined'
        }
        this.signOut = this.signOut.bind(this)
        this.signOutButton = this.signOutButton.bind(this)
    }

    signOut() {
        Cookies.remove('__session')
        this.setState({isAuthorized: false})
    }

    signOutButton() {
        return this.state.isAuthorized ?
            <Button className="justify-content-end" variant="light" onClick={this.signOut}>
                Sign out
            </Button> :
            null
    }

    render() {
        return (
            <div>
                <Navbar>
                    <Container fluid="md">
                        <Navbar.Brand><h2>SimpleCodeTT</h2></Navbar.Brand>
                        {this.signOutButton()}
                    </Container>
                </Navbar>
                <div className='container'>
                    <Router>
                        <Route path='/' render={
                            () => (
                                this.state.isAuthorized ?
                                    <Redirect to='/employees'/> :
                                    <Redirect to='/signin'/>
                            )
                        }

                        />
                        <Route path='/employees' component={Employee}/>
                        <Route path='/new-employee' component={AddEmployee}/>
                        <Route path='/edit-employee/:employeeId' component={EditEmployee}/>
                        <Route path='/signin' component={Login}/>
                        <Route path='/signup' component={Registration}/>
                    </Router>
                </div>
            </div>
        )
    }
}

export default App;
