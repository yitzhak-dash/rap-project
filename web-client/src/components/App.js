import React, {Component} from 'react';
import logo from './../logo.svg';
import './App.css';
import store from 'redux';
import StatisticsContainer from "./StatisticsContainer";
import TableContainer from "./TableContainer";
import CreateNewContainer from "./CreateNewContainer";

class App extends Component {

    constructor() {
        super();
        // dispatch(getAllProduct());
    }

    render() {
        return (
            <div className="App">
                <div>
                    <img src={logo} className="App-logo" alt="logo"/>
                </div>
                <div>
                    <StatisticsContainer/>
                </div>
                <div>
                    <TableContainer/>
                </div>
                <div>
                    <CreateNewContainer/>
                </div>
            </div>
        );
    }
}

export default App;
