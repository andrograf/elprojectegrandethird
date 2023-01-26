import {useState} from "react";
import "./Register.css";
import FormInput from "./FormInput"

const Login = () =>{
    const [values,setValues] = useState({

        email:"",
        password:"",
        required:true
    })

    const inputs = [
        {
            id:1,
            name:"Email",
            type:"text",
            placeholder:"Email",
            label: "username",
            required:true

        },
        {
        id:2,
            name:"Password",
            type:"password",
            placeholder:"Password",
            label: "password",
            required:true
        }
        ]


        const handleSubmit = (e)=>{
            e.preventDefault();
    
        };
    
        const onChange = (e)=>{
            setValues({...values, [e.target.name]: e.target.value})
        }

        return(
            <div className="login">
                <form onSubmit={handleSubmit}>
                <h1>Login</h1>
                    {inputs.map((input)=>(
    
                    <FormInput 
                    key={input.id}{...input} 
                    value={values[input.name]} 
                    onChange={onChange}/>
                    ))}
    
                    <button>Submit</button>
                <p>Don't have an account yet? Click here to register!</p>
                </form>
            </div>
        )

};export default Login;
