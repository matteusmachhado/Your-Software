import * as _ from "lodash";

export class appController
{

    texto(): void {
        let teste = _.join(['a', 'b', 'c'], '~');
        console.log(
            `Meu test meubem: ${teste}`
        );
    }
}

const teste = new appController();

teste.texto();