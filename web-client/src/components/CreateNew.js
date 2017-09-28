import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import {Field, reduxForm} from 'redux-form'

const required = value => value ? undefined : 'Required'
const maxLength = max => value =>
    value && value.length > max ? `Must be ${max} characters or less` : undefined;
const maxLength15 = maxLength(15);
const number = value => value && isNaN(Number(value)) ? 'Must be a number' : undefined;
const minValue = min => value =>
    value && value < min ? `Must be at least ${min}` : undefined;
const minValue18 = minValue(18);

const renderField = ({input, label, type, meta: {touched, error, warning}}) => (
    <div>
        <label>{label}</label>
        <div>
            <input {...input} placeholder={label} type={type}/>
            {touched && ((error && <span>{error}</span>) || (warning && <span>{warning}</span>))}
        </div>
    </div>
);

class CreateNew extends Component {
    render() {
        return (
            <div>
                <h3>Add New</h3>
                <form onSubmit={this.props.handleSubmit}>
                    <div>
                        <label htmlFor="shape">Shape</label>
                        <div>
                            <Field name="shape" component="select">
                                <option></option>
                                {this.props.shapes.map(item => (
                                    <option value={item}>{item}</option>
                                ))}
                            </Field>
                        </div>
                    </div>

                    <div>
                        <label>Size</label>
                        <div>
                            <Field name="size"
                                   component={renderField}
                                   validate={[required, number]} type="text" placeholder="Size"/>
                        </div>
                    </div>

                    <div>
                        <label>Color</label>
                        <div>
                            <Field name="color" component="select">
                                <option></option>
                                {this.props.colors.map(item => (
                                    <option value={item}>{item}</option>
                                ))}
                            </Field>
                        </div>
                    </div>

                    <div>
                        <label>clarity</label>
                        <div>
                            <Field name="clarity" component="select">
                                <option></option>
                                {this.props.clarity.map(item => (
                                    <option value={item}>{item}</option>
                                ))}
                            </Field>
                        </div>
                    </div>

                    <div>
                        <label>price</label>
                        <div>
                            <Field name="price"
                                   component={renderField}
                                   validate={[required, number]}
                                   type="text"
                                   placeholder="price"/>
                        </div>
                    </div>

                    <div>
                        <label>list Price</label>
                        <div>
                            <Field name="listPrice"
                                   component={renderField}
                                   validate={[required, number]}
                                   type="text" placeholder="list Price"/>
                        </div>
                    </div>

                    <div>
                        <button type="submit">Submit</button>
                    </div>
                </form>
            </div>
        );
    }
}

CreateNew = reduxForm({
    form: 'addNew'  // a unique identifier for this form
})(CreateNew);

export default CreateNew;