import React, { Component } from 'react';
import './GanttMaker.css'
import GanttForm from './GanttForm';

export class GanttMaker extends Component {
    static displayName = GanttMaker.name;

    constructor(props) {
        super(props);

    }


    render() {

        return (
            <div className="ganttMakerContainer">
                <script type="module">
                    import mermaid from 'https://unpkg.com/mermaid@9/dist/mermaid.esm.min.mjs';
                    mermaid.initialize("startOnLoad: true");
                </script>
                <h1 id="ganttMakerTitle" >Plan your workout!</h1>
                <p>This component demonstrates dynamic interaction with Mermaid.</p>
                <br></br>
                <div>
                    
                        <GanttForm />
                    <div className="responseViewer">
                    </div>
                </div>


            </div>
        );
    }
}
