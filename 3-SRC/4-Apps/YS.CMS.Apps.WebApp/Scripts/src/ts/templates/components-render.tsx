import React, { StatelessComponent } from "react";
import Title from "../templates/basic/components/Title";

export const AppComponents: StatelessComponent<{}> = () => {
    return (
        <div>
            <Title NomeComponent="Meu titulo" />
        </div>
    );
}