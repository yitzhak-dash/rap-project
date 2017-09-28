import {connect} from 'react-redux'
import {Table} from "./Table";


const mapStateToProps = state => {
    return {
        products: state.products
    }
};

const TableContainer = connect(
    mapStateToProps)
(Table);

export default TableContainer;