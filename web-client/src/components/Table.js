import React, {Component} from 'react';
//
import {BootstrapTable, TableHeaderColumn} from 'react-bootstrap-table';
import './../../node_modules/react-bootstrap-table/dist/react-bootstrap-table-all.min.css';

export class Table extends Component {

    constructor() {
        super();

        this.products = [{
            shape: 1,
            name: "Product1",
            price: 120,
            clarity: 120,

        }, {
            shape: 2,
            name: "Product2",
            price: 80,
            clarity: 80,
        }];
    }

    render() {
        return (
            <div>
                <h3>List:</h3>
                <BootstrapTable data={this.products} options={{noDataText: 'This is custom text for empty data'}}>
                    <TableHeaderColumn dataField='shape' isKey>shape</TableHeaderColumn>
                    <TableHeaderColumn dataField='name'>size</TableHeaderColumn>
                    <TableHeaderColumn dataField='price'>color</TableHeaderColumn>
                    <TableHeaderColumn dataField='clarity'>clarity</TableHeaderColumn>
                    <TableHeaderColumn dataField='price'>price</TableHeaderColumn>
                    <TableHeaderColumn dataField='listPrice'>list price</TableHeaderColumn>
                </BootstrapTable>
            </div>
        );
    }
}