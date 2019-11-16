import React, { Component } from 'react';
import { TweenMax, Bounce, Sine } from "gsap"; 
import './Loader.css'

type State = { }
type Props = { }

export default class Loader extends Component<Props, State>
{
    constructor(props: Props)   
    {
        super(props);
    }
        
    Loader: HTMLDivElement;
    componentDidMount() { }
    render() {
        return (
            <div className="Loader">
                <div ref={e => this.Loader = e}></div>
                <label>YS</label>
            </div>
        )
    }
}