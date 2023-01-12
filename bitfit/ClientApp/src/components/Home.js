import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;
    



    render() {
        return (
            <div className="modelContainer">
                <h1>Welcome Back to Bigidy Biceps</h1><br></br>
                <p>Many Thanks to <a href="https://calorieninjas.com/api">CalorieNinja</a> for dilligently collecting all that sweet nutritional data.</p>
                <h1 className="sampleData"> Sample of what you can expect!</h1>
                <br></br>


                <h2 className="shoutOut">Nutritional Pie Diagrams!</h2>
                <p>Get a quick overview on the selected foods with the main nutritional in a pie chart.</p>
                <br></br>
            </div>
        )
    }
}