import React, { StatelessComponent } from "react";
import Title from "../../../components/Title/Title";

export const AppComponents: StatelessComponent<{}> = () => {
    return (
        <div>
            <Title NomeComponent="Meu titulo" />
        </div>
    );
}