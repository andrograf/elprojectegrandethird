import mermaid from "mermaid";
import React from "react";

export class Mermaid extends React.Component {
    componentDidMount() {
        mermaid.contentLoaded();
    }
    refresh() {
        mermaid.parse(this.props.chart);
    }
    

    render() {
        return <div className="mermaid">{this.props.chart}</div>;
    }
}
