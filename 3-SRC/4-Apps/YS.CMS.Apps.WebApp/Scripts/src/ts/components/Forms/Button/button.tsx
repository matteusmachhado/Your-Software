import React, { StatelessComponent } from 'react';
import './Button.css';

interface Props {
    value: string;
    icon: string;
    onClick: () => void;
}

export const Button: StatelessComponent<Props> = (props) => {

  return (
      <button type="button"
          className="btn btn-lg btn-primary btn-block btn-button-custom" onClick={ () => props.onClick() }>
          {props.value}
          <span className={props.icon + " icon-btn"}></span>
    </button>
  );
};
