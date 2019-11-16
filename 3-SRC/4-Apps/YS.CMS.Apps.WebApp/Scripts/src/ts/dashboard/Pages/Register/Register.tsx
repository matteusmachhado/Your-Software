import React, { Component } from 'react';
import { Button } from './../../../components/Forms/index';
import Loader from './../../../components/Loader/Loader';
import './Register.css';
import iziToast from 'izitoast';

type Props = {
    Value: string;
}

type State = {
    UserName: string;
    Email: string;
    PhoneNumber: string;
    Password: string;
    ConfirmPassword: string;
    IsPersistent: boolean
}

export default class Register extends Component<Props, State>{

    constructor(props: Props) {
        super(props);
        this.state = {
            UserName: '',
            Email: '',
            PhoneNumber: '',
            Password: '',
            ConfirmPassword: '',
            IsPersistent: false
        }
    }

    registrar = async () => {
        console.clear();
        await fetch('http://localhost:5000/api/v1.0/register/', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.state)
        }).then(res => res.json())
        .then((response: any) => {
            if (response.ok) {
                console.log(response);
                iziToast.success({
                    title: 'Sucesso',
                    message: 'Cadastrao realizado.',
                });
                this.setState({
                    UserName: '',
                    Email: '',
                    PhoneNumber: '',
                    Password: '',
                    ConfirmPassword: '',
                    IsPersistent: false
                });
            } else {
                console.log(response);
                const keys = Object.keys(response);
                keys.map(key => `${key}: ${Reflect.get(response, key)}`).map((value, i) => {
                    iziToast.warning({
                        title: 'Atenção',
                        message: value,
                    });
                })
            }
        }).catch((response: any) => {
            console.log(response);
        });
    }

    render() {
        return (
            <form className="form-signin">
                <Loader />
                <div className="text-center mb-4">
                    <div className="form-label-group">
                        <input type="text" className="form-control" name="userName" placeholder="Nome de usuário" value={this.state.UserName} onChange={(e: React.ChangeEvent<HTMLInputElement>) => this.setState({ UserName: e.target.value })} />
                        
                    </div>
                    <div className="form-label-group">
                        <input type="text" className="form-control" name="Email" placeholder="E-mail" value={this.state.Email} onChange={(e: React.ChangeEvent<HTMLInputElement>) => this.setState({ Email: e.target.value })} />
                    </div>
                    <div className="form-label-group">
                        <input type="text" className="form-control" name="PhoneNumber" placeholder="Telefone" value={this.state.PhoneNumber} onChange={(e: React.ChangeEvent<HTMLInputElement>) => this.setState({ PhoneNumber: e.target.value })} />
                    </div>
                    <div className="form-label-group">
                        <input type="password" className="form-control" name="Password" placeholder="Senha" value={this.state.Password} onChange={(e: React.ChangeEvent<HTMLInputElement>) => this.setState({ Password: e.target.value })} />
                    </div>
                    <div className="form-label-group">
                        <input type="password" className="form-control" name="ConfirmPassword" placeholder="Confirmar senha" value={this.state.ConfirmPassword} onChange={(e: React.ChangeEvent<HTMLInputElement>) => this.setState({ ConfirmPassword: e.target.value })} />
                    </div>
                    <label className="btn-checked">
                        <input type="checkbox" name="IsPersistent" checked={this.state.IsPersistent} onClick={() => this.setState({ IsPersistent: !this.state.IsPersistent })} /> Lembrar-me
                    </label>    
                    <Button value="CADASTRAR" icon="fa fa-user-plus" onClick={() => this.registrar()} />
                </div>
            </form>
        );
    }
  
}