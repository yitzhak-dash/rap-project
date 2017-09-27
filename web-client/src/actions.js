/*
 * action types
 */
export const ADD_PRODUCT = 'ADD_PRODUCT';
export const GET_ALL_PRODUCTS = 'GET_ALL_PRODUCTS';

/*
 * action creators
 */
export const addProduct = ({shape, size, price, clarity, name, listPrice}) => {
    return {
        type: ADD_PRODUCT,
        shape, size, price, clarity, name, listPrice
    }
};

export const getAllProduct = () => {
    return {
        type: GET_ALL_PRODUCTS
    }
};
