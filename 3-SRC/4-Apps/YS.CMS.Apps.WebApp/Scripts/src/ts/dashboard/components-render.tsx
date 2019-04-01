﻿import React, { StatelessComponent } from "react";
import List from "./components/List";

export const AppComponents: StatelessComponent<{}> = () => {
    return (
        <div>
            <List NomeComponent="Lista de Testes . . .. " />
        </div>
    );
}