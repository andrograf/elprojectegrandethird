import {useState} from "react"
import {useRef} from "react"
import FormInput from "./FormInput"
import Loginstyle from "./Login.css"


const Login = () =>{
    // const [username,setUsername] = useState("")

    
    
    const handleSubmit = (e)=>{
        e.preventDefault();
        const data = new FormData(e.target)
        console.log(Object.fromEntries(data.entries()))
    }

    return(
        <div className="login">
            <form onSubmit={handleSubmit}>
                <FormInput name="username" placeholder="User name"/>
                <FormInput name ="fullname"placeholder="Full name"/>
                <FormInput name="email" placeholder="E-mail"/>
                <FormInput name="password" placeholder="Password"/>
                <button>Submit</button>
            </form>
        </div>
    )
};

export default Login;