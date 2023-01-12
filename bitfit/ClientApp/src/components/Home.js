import React, { Component } from 'react';


export class Home extends Component {
    static displayName = Home.name;
    



    render() {
        return (
            <div className="modelContainer">
                <h1>Welcome Back to Bigidy Biceps</h1><br></br>
                <p>Many Thanks to <a href="https://calorieninjas.com/api">CalorieNinja</a> for dilligently collecting all that sweet nutritional data.</p>
                <br></br>
            </div>
        )
    }
}