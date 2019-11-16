import React, { StatelessComponent } from 'react';
import { Input, Button } from './../../../components/Forms/index';
import Loader from './../../../components/Loader/Loader';
import './Register.css';

interface Props {
    Value: string;
}

export const Register: StatelessComponent<Props> = (props) => {
    return (
        <form className="form-signin">
            <Loader />
            <div className="text-center mb-4">
                <div className="form-label-group">
                    <Input
                        type="text"
                        name="userName"
                        placeholder="Nome de usuário"
                        value={props.Value}
                    />
                </div>
                <div className="form-label-group">
                    <Input
                        type="text"
                        name="userName"
                        placeholder="E-mail"
                        value={props.Value}
                    />
                </div>
                <div className="form-label-group">
                    <Input
                        type="text"
                        name="userName"
                        placeholder="Telefone"
                        value={props.Value}
                    />
                </div>
                <div className="form-label-group">
                    <Input
                        type="Password"
                        name="Password"
                        placeholder="Senha"
                        value={props.Value}
                    />
                </div>
                <div className="form-label-group">
                    <Input
                        type="Password"
                        name="Password"
                        placeholder="Confirmar Senha"
                        value={props.Value}
                    />
                </div>
                <Button value="Register" icon="fa fa-user-plus" />
            </div>
        </form>
    );
}