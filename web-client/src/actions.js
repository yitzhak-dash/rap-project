import fetch from 'isomorphic-fetch'

/*
 * action types
 */
export const ADD_PRODUCT = 'ADD_PRODUCT';
export const GET_ALL_PRODUCTS = 'GET_ALL_PRODUCTS';
export const GET_ALL_FAILED = 'GET_ALL_FAILED';

export const GET_COLORS = 'GET_COLORS';
export const GET_SHAPES = 'GET_SHAPES';
export const GET_CLARITY = 'GET_CLARITY';

const baseUrl = 'http://10.0.0.10:9003/api/';

/*
 * action creators
 */
export const addProduct = (item) => {
    return (dispatch) => {
        return dispatch(postProduct(item));
    };
};

const addProductSucceeded = (item) => {
    return {
        type: ADD_PRODUCT,
        item
    }
};

const postProduct = (item) => {
    return dispatch => {
        return fetch(`${baseUrl}/product`, {
            method: 'post',
            body: JSON.stringify(item),
            headers: {
                "Content-Type": "application/json",
                "Access-Control-Allow-Origin": "*",
                "Accept": "application/json",
            },
            mode: 'cors',
        }).then(() => dispatch(addProductSucceeded(item)))
            .catch(err => console.log('[*]ERROR:', err));
    }
};

export const getAllProduct = () => {
    return (dispatch) => {
        return dispatch(fetchProducts())
    };
};

export const getType = (typeName) => {
    return (dispatch) => {
        return dispatch(fetchType(typeName))
    };
};

export const fetchType = (typeName) => {
    return dispatch => {
        return fetch(`${baseUrl}/type/${typeName}`, {
            method: 'get',
            headers: {
                "Content-Type": "application/json",
                "Access-Control-Allow-Origin": "*",
                "Accept": "application/json",
            },
            mode: 'cors',
        }).then(parseJSON)
            .then(json => dispatch(receiveTypes(json, typeName)))
            .catch(err => dispatch(receiveTypesFailed(err)))
    }
};

const receiveTypes = (json, typeName) => {
    switch (typeName) {
        case 'color':
            return {
                type: GET_COLORS,
                data: json.$values,
            };
        case 'clarity':
            return {
                type: GET_CLARITY,
                data: json.$values,
            };
        case 'shape':
            return {
                type: GET_SHAPES,
                data: json.$values,
            }
    }
};

const receiveTypesFailed = (err) => {
    console.log(err);
    return {
        type: GET_ALL_FAILED,
        error: err.message
    }
};

const receiveProducts = (json) => {
    return {
        type: GET_ALL_PRODUCTS,
        products: json.$values,
        receivedAt: Date.now()
    }
};

const receiveProductsFailed = (err) => {
    console.log(err);
    return {
        type: GET_ALL_FAILED,
        error: err.message
    }
};

const parseJSON = (response) => {
    return response.text().then(function (text) {
        return text ? JSON.parse(text) : {}
    })
};

const fetchProducts = () => {
    return dispatch => {
        return fetch(`${baseUrl}/product`, {
            method: 'get',
            headers: {
                "Content-Type": "application/json",
                "Access-Control-Allow-Origin": "*",
                "Accept": "application/json",
            },
            mode: 'cors',
        }).then(parseJSON)
            .then(json => dispatch(receiveProducts(json)))
            .catch(err => dispatch(receiveProductsFailed(err)))
    }
};