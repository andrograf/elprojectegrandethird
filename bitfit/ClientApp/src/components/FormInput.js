import formInput from "../components/formInput.css"

const FormInput = (props) => {
    return (
        <div>
            {/* <label>Username</label> */}
            <input name={props.name}
            
            placeholder={props.placeholder} />
        </div>
        )
}

export default FormInput