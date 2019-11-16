import React, { Component } from "react";

type Props = {
    name: string;
    placeholder: string;
    type: string;
}

type State = {
    name: string;
    placeholder: string;
    value: string;
    type: string;
}

export default class Input extends Component<Props, State>{

    constructor(props: Props) {
        super(props);
        this.state = {
            name: '',
            placeholder: '',
            type: '',
            value: ''
        };
    }

    render() {
        return (
            <input type={this.props.type}
                name={this.props.name}
                className="form-control"
                placeholder={this.props.placeholder}
                value={this.state.value}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => { console.log(e.target.value); }}
            />
        )
    }
};
