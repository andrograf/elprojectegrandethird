import React, { useState } from 'react';
import './GanttMaker.css'

export default function GanttForm(){ 
    const [data, setData] = useState({
        title: ""
    });
    function handle(e){
        const newData = { ...data }
        newData[e.target.name] = e.target.value;
        setData(newData);
        console.log(newData);
    }
    return (
        <div className="ganttMakerContainer">
            <form action="https://localhost:7144/gantt" method="post">

                <label className="formLabel">Title</label>
                <input
                    type="text"
                    name="title"
                    value={data.title}
                    onChange={(e) => handle(e)}
                    placeholder="Enter your Title here"
                />

                <label className="formLabel">Exercises</label>
                <input

                />
                <button type="submit">Save Chart</button>
            </form>
        </div>
    )
}


