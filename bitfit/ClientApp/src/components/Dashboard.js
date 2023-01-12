import React, { Component } from 'react';
import profilePicture from '../images/ProfilePicture.jpeg';
import Button from './Button'

export class Dashboard extends Component {
    static displayName = Dashboard.name;




    render() {
        return (
            <div>
                <div>
                    <h1>Welcome user!</h1>
                </div>
                <div>
                    <img style={{ width: "160px", height: "160px", borderRadius: "80px" }} src={profilePicture} alt="profilePicture" />
                </div>
                <div>
                    <br></br>
                    <Button color="#1b6ec2" className="nav-link text-dark" text="Click here to add profile picture" />
                </div>
                <br>
                </br>
                <div>
                    <table className='table table-striped' aria-labelledby="tabelLabel">

                        <thead>
                            <tr>
                                <th>Name:</th>
                                <th>Birth date:</th>
                                <th>Gender:</th>
                                <th>Height:</th>
                                <th>Weight:</th>
                            </tr>
                        </thead>
                        </table>
                </div>
            </div>
        )
    }
}
export default Dashboard;