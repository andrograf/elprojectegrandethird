import loadingGif from '../images/loading.gif';
import React from 'react';
import './Loading.css';

function Loading() {
    return (
        <div className="loadingCard">
            <img src={loadingGif} alt="poopies" />
        </div>
        )
}

export default Loading;