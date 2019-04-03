import React, { Component } from 'react';
import { TweenMax } from "gsap"; 

type State = { }
type Props = { }

export default class SpinnerCircle extends Component<Props, State>
{
    state = {
        // >_  ...
    }

    render() {
        return (
            <>
                <div className="d-flex justify-content-center">
                    <div className="spinner-border text-primary" role="status">
                        <span className="sr-only">Loading...</span>
                    </div>
                </div>
            </>
        )
    }
}