import {useState} from "react"

import FormInput from "./FormInput"
import "./Register.css"


const Login = () =>{
    const [values,setValues] = useState({
        username:"",
        fullname:"",
        email:"",
        password:"",
        confirmPassword: "",
        required:true
    })

    const inputs = [
        {
            id:1,
            name:"Username",
            type:"text",
            placeholder:"username",
            errorMessage: "Should be 3-16 charachters without any special charachters.",
            label: "username",
            pattern: "^[A-Za-z0-9]{3,16}$",
            required:true

        },
        {
            id:2,
            name:"email",
            type:"email",
            placeholder:"Email",
            errorMessage:"This should be a valid email address",
            label: "Email",
            pattern: "^(([^<>()[\]\\.,;:\s@] + (\.[^<>()[\]\\.,;:\s@]+)*)|(.+))@((\[[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$",
            required:true

        },
        {
            id:3,
            name:"password",
            type:"password",
            placeholder:"Password",
            errorMessage:"Should be 8-20 charachters, contains at least one capital letter, one number, one special character.",
            label: "Password",
            pattern: "^(?=.*[0-9])(?=.*[A-Za-z])(?=.*[!@#$%^&*()_+])[A-Za-z0-9!@#$%^&*()_+]{8,20}$",
            required:true

        },
        {
            id:4,
            name:"confirmPassword",
            type:"password",
            placeholder:"Confirm password",
            errorMessage:"Passwords doesn't match",
            label: "Confirm password",
            pattern: values.password,
            required:true

        }
    ]
    
    
    const handleSubmit = (e)=>{
        e.preventDefault();

    };

    const onChange = (e)=>{
        setValues({...values, [e.target.name]: e.target.value})
    }

    console.log(values);

    return(
        <div className="login">
            <form onSubmit={handleSubmit}>
            <h1>Register</h1>
                {inputs.map((input)=>(

                <FormInput 
                key={input.id}{...input} 
                value={values[input.name]} 
                onChange={onChange}/>
                ))}

                <button>Submit</button>
            <p>Already have an account? Click here to login!</p>
            </form>
        </div>
    )
};

export default Login;