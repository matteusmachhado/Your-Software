import React, { Component } from 'react';
import './Title.css';

type State = {
    Title: string
}
type Props = {
    NomeComponent: string
}

export default class Title extends Component<Props, State>
{
    constructor(props: Props)
    {
        super(props);
    }

    render() 
    {
        return (
            <h1 className="MyTitle"> >_ Teste</h1>
        )
    }
}