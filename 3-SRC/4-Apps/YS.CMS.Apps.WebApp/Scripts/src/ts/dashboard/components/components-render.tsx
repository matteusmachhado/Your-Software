import React, { StatelessComponent } from "react";
import List from "../../components/List/List";
import SpinnerCircle from './../../components/SpinnerCircle/SpinnerCircle';

export const AppComponents: StatelessComponent<{}> = () => {
    return (
        <div>
            <SpinnerCircle />
        </div>
    );
}
