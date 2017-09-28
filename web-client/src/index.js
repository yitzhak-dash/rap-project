import React from 'react'
import {render} from 'react-dom'
import {Provider} from 'react-redux'
import {createStore, applyMiddleware, combineReducers} from 'redux'
import thunkMiddleware from 'redux-thunk'
import {createLogger} from 'redux-logger'
import {products, types} from './reducers'
import {getAllProduct, getType} from "./actions";
import {reducer as formReducer} from 'redux-form';
import App from './components/App'

const loggerMiddleware = createLogger();

const reducers = {
    products,
    types,
    form: formReducer
};

const reducer = combineReducers(reducers);

const store = createStore(
    reducer,
    applyMiddleware(
        thunkMiddleware, // lets us dispatch() functions
        loggerMiddleware // neat middleware that logs actions
    )
);

store.dispatch(getAllProduct());
store.dispatch(getType('color'));
store.dispatch(getType('shape'));
store.dispatch(getType('clarity'));

render(
    <Provider store={store}>
        <App/>
    </Provider>,
    document.getElementById('root')
);
