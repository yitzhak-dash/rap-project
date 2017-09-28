import * as actionTypes from "./actions";

export const products = (state = [], action) => {
    switch (action.type) {
        case actionTypes.ADD_PRODUCT:
            return [
                ...state,
                action.item
            ];
        case actionTypes.GET_ALL_PRODUCTS:
            return [...action.products];
        default:
            return state
    }
};

export const types = (state = {
    colors: [],
    shapes: [],
    clarity: []
}, action) => {
    switch (action.type) {
        case actionTypes.GET_COLORS:
            return {
                ...state,
                colors: action.data
            };
        case actionTypes.GET_SHAPES:
            return {
                ...state,
                shapes: action.data
            };
        case actionTypes.GET_CLARITY:
            return {
                ...state,
                clarity: action.data
            };
            return [...action.products];
        default:
            return state
    }
};


