import {useState} from "react"

import FormInput from "./FormInput"
import "./Login.css"


const Login = () =>{
    const [values,setValues] = useState({
        username:"",
        fullname:"",
        email:"",
        password:"",
        confirmPassword:""
    })

    const inputs = [
        {
            id:1,
            name:"Username",
            type:"text",
            placeholder:"username",
            label:"username"
        },
        {
            id:2,
            name:"email",
            type:"text",
            placeholder:"Email",
            label:"Email"
        },
        {
            id:3,
            name:"password",
            type:"password",
            placeholder:"Password",
            label:"Password"
        },
        {
            id:4,
            name:"confirmPassword",
            type:"password",
            placeholder:"Confirm password",
            label:"Confirm password"
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