import React, { useState } from 'react';
import { Mermaid } from './Mermaid';
import moment from "moment";


export default function ChallengeForm() { 

    const [data, setData] = useState({ title: "Your Title Here" });
    let now = moment().format("YYYY-MM-DD");

    let chart =
        `gantt
    title ${data.title}
    dateFormat  YYYY-MM-DD
    axisFormat  %Y-%m-%d
    Initial milestone : milestone, m1, ${now}, 60m

    section Calorie
    Selected Foods Go Here :f1, ${now}, 160m

    section Exercises
    Selected Exercises Go Here :e1, ${now}, 160m
    Neatly Separated    : 110m
    With Different Lengths : 220m`;

   
    function handle(e){
        const newData = { ...data };
        newData[e.target.name] = e.target.value;
        setData(newData);
    }


    return (
        <div className="ganttFormContainer">
            <form action="https://localhost:7144/gantt/new" method="post">

                <select name="challengeType">
                    <option value="generalFitness">General Fitness</option>
                    <option value="weightLoss">Weight Loss</option>
                </select>

                <select name="dietPlan">
                    <option value="myFoods">My Foods</option>
                    <option value="ketoDiet">Keto Diet</option>
                </select>
                <button type="submit">Generate Chart</button>
            </form>
            <Mermaid chart={chart} />
        </div>
    )
}


