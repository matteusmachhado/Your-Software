import React, { Component } from 'react';

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
        return this.Id
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
    
    componentDidMount()
    {
        let Items: Array<ItemLits> = [
            new ItemLits(1, "Item"),
            new ItemLits(2, "Item"),
            new ItemLits(3, "Item"),
        ];

        this.setState({ Items: Items });
    }

    render() {
        return (
            <div>
                <h1> { this.props.NomeComponent } </h1>
                <ul>
                {
                    this.state.Items.map(function (item, i) {
                        return (
                            <li key={item.getId} > {item.getValue} </li>      
                        );
                    })
                }
                </ul>
            </div>
        )
    }
}