import {connect} from 'react-redux'
import CreateNew from "./CreateNew";
import {addProduct} from "./../actions";

let newItem = null;

const mapStateToProps = state => {
    if (state.form.addNew) {
        newItem = state.form.addNew.values;
    }
    return {
        newProduct: newItem,
        colors: state.types.colors,
        shapes: state.types.shapes,
        clarity: state.types.clarity
    }
};

const mapDispatchToProps = dispatch => {
    return {
        handleSubmit: (values) => {
            values.bubbles = false;
            console.log('submit clicked', newItem);
            dispatch(addProduct(newItem));
        }
    }
};


const CreateNewContainer = connect(
    mapStateToProps,
    mapDispatchToProps)
(CreateNew);

export default CreateNewContainer;