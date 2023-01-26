import { useState } from "react";
import "../components/formInput.css"
import "../components/Register.css"

const FormInput = (props) => {
    const [focused, setFocused] = useState(false);
    const { label, errorMessage, onChange, id, ...inputProps } = props;
    const handleFocused = (e) => {
        setFocused(true);
    };
    return (
        <div className="formInput">
        
            <label>{label}</label>
            <input
                {...inputProps}
                onChange={onChange}
                onBlur={handleFocused}
                onFocus={() =>
                    inputProps.name === "confirmPassword" && setFocused(true)}
                focused={focused.toString()}
            />
            <span>{errorMessage}</span>
        </div>
        )
}

export default FormInput