import React, { StatelessComponent } from "react";
import List from "../../components/List/List";
import SpinnerCircle from './../../components/SpinnerCircle/SpinnerCircle';
import Logo from './../../components/Logo/Logo';

export const AppComponents: StatelessComponent<{}> = () => {
    return (
        <div>
            <SpinnerCircle />
        </div>
    );
}
