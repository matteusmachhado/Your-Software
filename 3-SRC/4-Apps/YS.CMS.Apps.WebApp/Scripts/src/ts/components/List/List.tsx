import React, { Component } from 'react';
import './List.css';
import 'bootstrap/js/dist/modal.js';
import jsImage from './js-flat.png';
import { setTimeout } from 'timers';
import SpinnerCircle from './../SpinnerCircle/SpinnerCircle';

type State  = {
    Items: Array<ItemLits>,
    Display: boolean
}
type Props = {
    NomeComponent: string
}

class ItemLits
{
    constructor(private Id: number, private Value: string )
    {

    }

    get getId()
    {
        return this.Id;
    }

    get getValue()
    {
        return this.Value;
    }

}

const getInitialState = (props: Props): State =>  {
    return {
        Items: Array<ItemLits>(),
        Display: false
    }
}


export default class List extends Component<Props, State>
{
    state = getInitialState(this.props);

    constructor(prop: Props)
    {
        super(prop);
        this.showMensagem = this.showMensagem.bind(this);
    }
    
    componentDidMount()
    {
        let Items: Array<ItemLits> = [
            new ItemLits(1, "Item 1"),
            new ItemLits(2, "Item 2"),
            new ItemLits(3, "Item 3"),
            new ItemLits(4, "Item 4"),
            new ItemLits(5, "Item 5"),
            new ItemLits(6, "Item 6"),
            new ItemLits(7, "Item 7")
        ];
        setTimeout(() => {
            console.log("Fui chamado depois de 5 segundos...");
            this.setState({ Items: Items, Display: false });
        }, 5000);
    }

    showMensagem() : void
    {
        console.log("Minha mensagem. . .");
    }

    render() {
        console.log("Render...");
        
        let component = (
            <>
                <h1 className="h1Titulo" onClick={this.showMensagem}> {this.props.NomeComponent} </h1>
                <img src={jsImage} />
                <ul className="list-group">
                    {
                        this.state.Items.map(function (item, i) {
                            return (
                                <li key={item.getId} className="list-group-item"> {item.getValue} </li>
                            );
                        })
                    }
                </ul>
            </>
        );

        if (!this.state.Display) { component = <SpinnerCircle /> } 

        return (
            <>
                {component}
            </>
        )
    }

}