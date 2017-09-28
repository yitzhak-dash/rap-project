import React, {Component} from 'react';
import ReactDOM from 'react-dom';

export class Statistics extends Component {

    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div>
                <h1>Statistics</h1>
                <ul>
                    <li>average price:{this.props.average}</li>
                    <li>number of diamonds:{this.props.count}</li>
                    <li>average discount:{this.props.discount}%</li>
                </ul>
            </div>
        );
    }
}