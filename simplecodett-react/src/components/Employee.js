import React, {Component} from 'react';
import {Button} from 'react-bootstrap';
import {Link} from 'react-router-dom';
import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";
import Cookies from 'js-cookie'
import moment from 'moment'

const LOCALE = window.navigator.userLanguage || window.navigator.language;
const REACT_APP_API = 'https:localhost:44359/api/'

class Employee extends Component {
    constructor() {
        super();
        // changing to current locale
        moment.locale(LOCALE);

        this.state = {
            emps: []
        };

        this.columns = [
            {
                dataField: 'name',
                text: 'Name',
                sort: true
            },
            {
                dataField: 'email',
                text: 'Email',
                sort: true
            },
            {
                dataField: 'birthday',
                text: 'Birthday',
                sort: true,
                formatter: (cell) => {
                    let dateObj = cell;
                    if (typeof cell !== 'object') {
                        dateObj = new Date(cell);
                    }
                    return moment(dateObj).format('L').toString();
                }
            },
            {
                dataField: 'salary',
                text: 'Salary',
                sort: true
            },
            {
                dataField: 'lastModifiedDate',
                text: 'Last Modified Date',
                sort: true,
                formatter: (cell) => {
                    let dateObj = cell;
                    if (typeof cell !== 'object') {
                        dateObj = new Date(cell);
                    }
                    // TODO: Refactor
                    return moment(dateObj).format('L').toString() + ' ' + moment(dateObj).format('LTS').toString();
                }
            }, {
                dataField: "edit",
                text: '',
                sort: false,
                formatter: (cellContent, row) => {
                    return (
                        <Link to={{
                            pathname: 'edit-employee/' + row.id,
                            state: row
                        }}>
                            <Button variant="primary">Edit</Button>
                        </Link>
                    );
                },
                headerAttrs: {width: 70},
                attrs: {width: 50, className: "EditRow"}
            },
            {
                dataField: "delete",
                sort: false,
                formatter: (cellContent, row) => {
                    return (
                        <Button variant="danger" onClick={() => this.deleteEmployee(row.id)}>Delete</Button>
                    );
                },
                headerAttrs: {width: 90},
                attrs: {width: 50, className: "DeleteRow"}
            }];
        this.authString = 'Bearer ' + Cookies.get('__session')
    }

    refreshList() {
        const requestOptions = {
            method: 'GET',
            headers: {
                'accept': 'application/json',
                'Authorization': this.authString
            }
        }
        fetch(REACT_APP_API + 'employees', requestOptions)
            .then(response => response.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        emps: result.result
                    });
                });
    }

    deleteEmployee(rowId) {
        if (window.confirm('Are you sure you wish to delete this item?')) {
            const requestOption = {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': this.authString
                }
            }
            fetch(REACT_APP_API + 'employees/' + rowId, requestOption)
                .then(() => this.refreshList())
        }
    }

    componentDidMount() {
        this.refreshList()
    }

    render() {
        return (
            <div className="container">
                <Link to='new-employee'>
                    <Button variant='primary'>
                        Add Employee</Button>
                </Link>

                <div className="mt-3">
                    <BootstrapTable
                        bootstrap4
                        keyField="id"
                        data={this.state.emps}
                        columns={this.columns}
                        pagination={paginationFactory({sizePerPage: 10})}
                        bordered={false}
                    />
                </div>
            </div>
        )
    }
}

export default Employee