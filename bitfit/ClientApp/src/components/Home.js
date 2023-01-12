import React, { Component } from 'react';
import './Home.css';
import mermaid from "mermaid";
import data from '../images/diagramData.png';


export class Home extends Component {
    static displayName = Home.name;
    



    render() {
        let chart =
            `gantt
    title This Weeks Dev Activity
    dateFormat  YYYY-MM-DD
    axisFormat  %Y-%m-%d
    Initial milestone : milestone, m1, 2022-12-12, 60m

    section Documentation
    Setup Default Task Tracking :a1, 2022-12-12, 160m
    Add Base Weekly Issues     :a2, 2022-12-13, 210m
    Add Specific Weekly Issues     :a2, 2022-12-14, 210m
    Update Weekly Documentation    : 2022-12-15, 90m
    
    section Backend
    Add Default MvC .Net Application :2022-12-13, 160m
    Establish skeleton structure    : 110m
    Add Index Page    : 2022-12-14  , 110m
    Add Foods Page    : 140m
    Add Recipes Page  : 220m
    Update Model Binding : 80m

    section Frontend
    Add Index style    : 2022-12-15  , 110m
    Add Foods style    : 110m

    section Other
    BrainStorming Session   : 2022-12-12  , 240m
    Searching for Nutritional Api    : 110m
    Daily Team Meeting   : 2022-12-13  , 40m
    Bugfix-Add Constructor for Json data parsing : 80m
    Daily Team Meeting   : 2022-12-14  , 40m
    Bugfix-Mermaid value handling: 55m
    Daily Team Meeting   : 2022-12-15  , 40m
    Searching for Recipe Api : 180m

    Final milestone : milestone, m2, 2022-12-16, 12m`;

                                                    
        let diagramOne = `pie
title apple
"protein_g": 0.3
"sugar_g": 10.3
"fiber_g": 2.4
"fat_total_g": 0.2`;
        let diagramTwo = `pie
title bread
"protein_g": 8.8
"sugar_g": 5.7
"fiber_g": 2.7
"fat_total_g": 3.4`;
        let diagramThree = `pie
title potato
"protein_g": 2.5
"sugar_g": 1.2
"fiber_g": 2.2
"fat_total_g": 0.1`;
        return (
            <div className="modelContainer">
                <script type="module">
                    import mermaid from 'https://unpkg.com/mermaid@9/dist/mermaid.esm.min.mjs';
                    mermaid.initialize("startOnLoad: true");
                </script>
                <h1>Welcome Back to Bigidy Biceps</h1><br></br>
                <p>Many Thanks to <a href="https://calorieninjas.com/api">CalorieNinja</a> for dilligently collecting all that sweet nutritional data.</p>
                <br></br>
                
                <div class="foodContainer">
                    <Mermaid className="foodCard" chart={diagramOne} />
                    
                <Mermaid className="foodCard" chart={diagramTwo} />
                <Mermaid className="foodCard" chart={diagramThree} />
                </div>
                <div className="diagramData">
                <img src={data} alt="diagram details"/>
                </div>
                <br></br>
                <h2 class="shoutOut">Activity Tracking In Gantt!</h2>
                <Mermaid chart={chart} />

            </div>
        )
    }
}




mermaid.initialize({
    startOnLoad: true
});

class Mermaid extends React.Component {
    componentDidMount() {
        mermaid.contentLoaded();
    }

    render() {
        return <div className="mermaid">{this.props.chart}</div>;
    }
}

