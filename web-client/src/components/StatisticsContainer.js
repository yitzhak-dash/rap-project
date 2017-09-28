import {connect} from 'react-redux'
import {Statistics} from "./Statistics";

const round = (value, precision) => {
    const multiplier = Math.pow(10, precision || 0);
    return Math.round(value * multiplier) / multiplier;
};
const getAverage = array => round(array.reduce((acc, current) => acc + current, 0) / array.length, 2);
const getAverageDiscount = products => {
    const total = products.map(item => item.listPrice).reduce((acc, current) => acc + current, 0);
    const totalDiscount = products.reduce((acc, current) => acc + (current.listPrice - current.price), 0);
    return round(totalDiscount / total * 100, 2);
};

const mapStateToProps = state => {
    return {
        average: getAverage(state.products.map(item => item.price)),
        count: state.products.length,
        discount: getAverageDiscount(state.products)
    }
};

const StatisticsContainer = connect(
    mapStateToProps)
(Statistics);

export default StatisticsContainer;