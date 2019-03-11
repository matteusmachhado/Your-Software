import * as React from "react";
import * as reactDOM from "react-dom";
import List from "./components/List";

export const AppComponents: React.StatelessComponent<{}> = () => {
    return (
        <List NomeComponent="Lista de Testes . . ." />
    );
}