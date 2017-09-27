import * as actionTypes from "./actions";

const initialState = {
    products: []
};

export const products = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.ADD_PRODUCT:
            return [
                ...state,
            ];
        case actionTypes.GET_ALL_PRODUCTS:
            return [{
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
        default:
            return state
    }
};


