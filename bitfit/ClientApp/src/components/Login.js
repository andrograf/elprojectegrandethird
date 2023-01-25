import {useState} from "react"

import FormInput from "./FormInput"
import "./Login.css"


const Login = () =>{
    const [values,setValues] = useState({
        username:"",
        fullname:"",
        email:"",
        password:"",
        confirmPassword:"",
        required:true
    })

    const inputs = [
        {
            id:1,
            name:"Username",
            type:"text",
            placeholder:"username",
            errorMessage: "Username should be 3-16 charachters, and shouldn't include any special charachters.",
            label:"username",
            required:true

        },
        {
            id:2,
            name:"email",
            type:"text",
            placeholder:"Email",
            errorMessage:"This should be a valid email address",
            label:"Email",
            required:true

        },
        {
            id:3,
            name:"password",
            type:"password",
            placeholder:"Password",
            errorMessage:"Should be 8-20 charachters",
            label:"Password",
            required:true

        },
        {
            id:4,
            name:"confirmPassword",
            type:"password",
            placeholder:"Confirm password",
            errorMessage:"Passwords doesn't match",
            label:"Confirm password",
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
            </form>
        </div>
    )
};

export default Login;