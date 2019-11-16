import React, { StatelessComponent } from 'react';
import './Button.css';

interface Props {
    value: string;
    icon: string;
}

export const Button: StatelessComponent<Props> = (props) => {

  return (
    <button type="button"
          className="btn btn-lg btn-primary btn-block btn-button-custom">
          {props.value}
          <span className={props.icon + " icon-btn"}></span>
    </button>
  );
};
