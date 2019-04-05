import React, { Component } from 'react';
import { TweenMax, Bounce } from "gsap"; 
import './SpinnerCircle.css';

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
        TweenMax.to(this.Spinner, 2, { 
            ease: Bounce.easeOut, 
            rotation: '360deg',
            repeat: -1,
            borderRadius: '50%', 
            scale: .7,
            yoyo: true
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