import React, { StatelessComponent } from "react";
import List from "./components/List";

export const AppComponents: StatelessComponent<{}> = () => {
    return (
        <List NomeComponent="Lista de Testes . . ." />
    );
}