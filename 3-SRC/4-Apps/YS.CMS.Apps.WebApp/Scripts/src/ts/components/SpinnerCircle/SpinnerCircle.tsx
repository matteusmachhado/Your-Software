﻿import React, { Component } from 'react';
import { TweenMax, Bounce, TweenLite, Power0 } from "gsap"; 
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
    TesteSVG: HTMLDivElement;

          
    componentDidMount() {   
        TweenMax.to(this.Spinner, 2, { 
            ease: Bounce.easeOut, 
            rotation: '360deg',
            repeat: -1,
            borderRadius: '50%', 
            scale: .7,
            yoyo: true
        });

        TweenMax.from(this.TesteSVG, .5, {
            scaleY: .7,
            transformOrigin: 'bottom center',
            ease: Power0.easeOut,   
            repeat: -1,
            yoyo: true
        });

    }

    //
     
    render() {
        return (
            <>
                <div className="square-ball" ref={e => this.Spinner = e}></div>
                <div ref={e => this.TesteSVG = e}>
                    <svg version="1.1" id="logo" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
	                     width="50.333px" height="50.334px" viewBox="0 0 533.333 533.334" >
                        <g>
	                        <path d="M433.333,166.667H400v-50c0-46.024-89.542-83.333-200-83.333S0,70.643,0,116.667v300C0,462.69,89.542,500,200,500
		                        s200-37.31,200-83.333v-50h33.334c54.999,0,100-45.001,100-100C533.333,211.667,488.333,166.667,433.333,166.667z M91.695,98.751
		                        C121.874,88.808,160.336,83.333,200,83.333c39.664,0,78.126,5.475,108.305,15.417c19.267,6.348,30.94,13.149,37.191,17.916
		                        c-6.251,4.767-17.925,11.567-37.191,17.916C278.126,144.525,239.664,150,200,150c-39.664,0-78.126-5.475-108.305-15.417
		                        c-19.268-6.349-30.941-13.149-37.192-17.916C60.754,111.9,72.428,105.1,91.695,98.751z M471.022,296.022
		                        c-4.598,4.598-14.525,12.311-29.355,12.311H400V225h41.667c14.83,0,24.758,7.714,29.355,12.312
		                        c4.599,4.598,12.312,14.525,12.312,29.355C483.333,281.496,475.621,291.425,471.022,296.022z"/>
                        </g>
                    </svg>
                </div>
            </>
        )
    }
}