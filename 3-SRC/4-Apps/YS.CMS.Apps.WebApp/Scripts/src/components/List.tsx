import * as React from 'react';

interface State {
    Items: Array<ItemLits>;
}
interface Props {

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

export default class List extends React.Component<Props, State> {

    constructor(props: Props)
    {
        super(props);
        this.state = { Items: Array<ItemLits>() }
    }
    
    componentDidMount()
    {
        let Items: Array<ItemLits> = [
            new ItemLits(1, "Item"),
            new ItemLits(2, "Item")
        ];

        this.setState({ Items: Items });
    }

    render() {
        return (
            <ul>
                {
                    this.state.Items.map(function (item, i) {
                        return (
                            <li key={item.getId} > {item.getValue} </li>      
                        );
                    })
                }
            </ul>
        );
    }
}