import React, { Component } from 'react';
import { TweenLite, Bounce } from "gsap"; 
import './SpinnerCircle.css';
import { setInterval } from 'timers';

type State = { }
type Props = { }

export default class SpinnerCircle extends Component<Props, State>
{
    constructor(props: Props)   
    {
        super(props);   
    }
        
    Spinner: HTMLDivElement;
          
    componentDidMount() {   
        TweenLite.to(this.Spinner, 2, { 
            ease: Bounce.easeOut, 
            rotation: '360deg',
            repeat: -1,
            borderRadius: '50%', 
            scale: .7,
        });
    }
     
    render() {
        return (
            <>
                <div className="square-ball" ref={e => this.Spinner = e}></div>
            </>
        )
    }
}