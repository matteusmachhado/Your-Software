import React, { StatelessComponent } from "react";
import List from "./components/List";
import Titulo from "../templates/basic/components/Titulo";

export const AppComponents: StatelessComponent<{}> = () => {
    return (
        <div>
            <List NomeComponent="Lista de Testes . . .. " />
            <Titulo NomeComponent="Meu titulo" />
            <Titulo NomeComponent="Meu titulo" />
        </div>
    );
}