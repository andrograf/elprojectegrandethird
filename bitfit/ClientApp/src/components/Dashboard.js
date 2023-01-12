import React, { Component } from 'react';
import profilePicture from '../images/ProfilePicture.jpeg';

export class Dashboard extends Component {
    static displayName = Dashboard.name;




    render() {
        return (
            <div>
                <div>
                    <h1>Welcome user!</h1>
                </div>
                <div>
                    <img style={{width:"160px", height:"160px", borderRadius:"80px"} } src={profilePicture} alt="profilePicture"/>
                </div>
            </div>
        )
    }
}