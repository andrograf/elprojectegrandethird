import React, { Component } from 'react';
import Loading from './Loading'
import mermaid from "mermaid";
import './GanttMaker.css'

export class GanttMaker extends Component {
    static displayName = GanttMaker.name;

    constructor(props) {
        super(props);
    }

    async getSampleFoods() {
        const url = "https://localhost:7144/gantt/";
        fetch(url, {
            method: "Post"
        })
            .then(resp => resp.json())
            .then(data => this.setState({ gantt: data, loading: false }))
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
                </div>


            </div>
        );
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
