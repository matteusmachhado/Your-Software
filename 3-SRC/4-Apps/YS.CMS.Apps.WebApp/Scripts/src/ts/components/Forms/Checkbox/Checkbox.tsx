import React, { StatelessComponent } from 'react';
import './Checkbox.css';

interface Props {
    label: string;
    name: string;
}

export const Checkbox: StatelessComponent<Props> = (props) => {

    return (
        <div className="checkbox mb-3">
            <label>
                <input type="checkbox"
                    className="form-check-input"
                    name={props.name}>
                </input> {props.label}
            </label>
        </div>
      
  );
};
