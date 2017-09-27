import React, {Component} from 'react';
import ReactDOM from 'react-dom';

export class CreateNew extends Component {
    render() {
        return (
            <div>
                <h3>Add New</h3>
                <form>
                    <label>
                        name:
                        <input type="text" name="name" />
                    </label>
                    <label>
                        shape:
                        <input type="text" name="shape" />
                    </label>
                    <label>
                        price:
                        <input type="text" name="price" />
                    </label>
                    <label>
                        clarity:
                        <input type="text" name="clarity" />
                    </label>
                    <label>
                        price:
                        <input type="text" name="price" />
                    </label>
                    <label>
                        list price:
                        <input type="text" name="listPrice" />
                    </label>
                    <input type="submit" value="Submit" />
                </form>
            </div>
        );
    }
}