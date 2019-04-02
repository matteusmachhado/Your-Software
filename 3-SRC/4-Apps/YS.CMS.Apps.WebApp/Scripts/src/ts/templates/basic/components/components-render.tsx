import React, { StatelessComponent } from "react";
import Title from "../../../components/Title/Title";

export const AppComponents: StatelessComponent<{}> = () => {
    return (
        <div className="container-fluid">
            <Title NomeComponent="Meu titulo" />
        </div>
    );
}