import React, { StatelessComponent } from "react";

interface Props {
    name: string;
    placeholder: string;
    value: string;
    type: string
}

export const Input: StatelessComponent<Props> = (props) => {
    return (
        <input type={props.type}
          name={props.name}
          className="form-control"
          placeholder={props.placeholder}
          value={props.value}
        />
  )
};