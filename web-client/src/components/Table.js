import React, {Component} from 'react';
import {connect} from 'react-redux';
//
import {BootstrapTable, TableHeaderColumn} from 'react-bootstrap-table';
import './../../node_modules/react-bootstrap-table/dist/react-bootstrap-table-all.min.css';

export class Table extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <h3>List:</h3>
                <BootstrapTable data={this.props.products} options={{noDataText: 'This is custom text for empty data'}}>
                    <TableHeaderColumn dataField='shape' isKey>shape</TableHeaderColumn>
                    <TableHeaderColumn dataField='size'>size</TableHeaderColumn>
                    <TableHeaderColumn dataField='color'>color</TableHeaderColumn>
                    <TableHeaderColumn dataField='clarity'>clarity</TableHeaderColumn>
                    <TableHeaderColumn dataField='price'>price</TableHeaderColumn>
                    <TableHeaderColumn dataField='listPrice'>list price</TableHeaderColumn>
                </BootstrapTable>
            </div>
        );
    }
}
