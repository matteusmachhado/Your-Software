import React, { Component } from 'react';

type State = {
    Title: string
}
type Props = {
    NomeComponent: string
}

export default class Titulo extends Component<Props, State>
{
    constructor(props: Props)
    {
        super(props);
    }

    render() 
    {
        return (
            <h1>"teste"</h1>
        )
    }
}