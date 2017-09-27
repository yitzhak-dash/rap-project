import React, {Component} from 'react';
import logo from './../logo.svg';
import './App.css';
import {Statistics} from "./Statistics";
import {Table} from "./Table";
import {CreateNew} from "./CreateNew";

class App extends Component {
    render() {
        return (
            <div className="App">
                <div className="App-header">
                    <img src={logo} className="App-logo" alt="logo"/>
                    <h2>Welcome to React</h2>
                </div>
                <div>
                    <Statistics/>
                </div>
                <div>
                    <Table/>
                </div>
                <div>
                    <CreateNew/>
                </div>
            </div>
        );
    }
}

export default App;
