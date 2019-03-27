import React, { Component } from 'react';
import './css/List.css';
import 'bootstrap/js/dist/modal.js';
import jsImage from './../Images/js-flat.png';

type State  = {
    Items: Array<ItemLits>
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
        Items: Array<ItemLits>()
    }
}

export default class List extends Component<Props, State> {

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
            new ItemLits(5, "Item 5"),
        ];

        this.setState({ Items: Items });
    }

    showMensagem() : void
    {
        console.log("Minha mensagem. . .");
    }

    render() {
        return (
            <div>
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
            </div>
        )
    }
}