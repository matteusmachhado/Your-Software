import React, { StatelessComponent } from 'react';
import { Input, Button } from './../../../components/Forms/index';
import Loader from './../../../components/Loader/Loader';
import './Login.css';

interface Props {
    Value: string;
}

export const Login: StatelessComponent<Props> = (props) => {
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
                        type="Password"
                        name="Password"
                        placeholder="Senha"
                        value={props.Value}
                    />
                </div>
               
                <Button value="Login" icon="fa fa-sign-out"/>
            </div>
        </form>
    );
}