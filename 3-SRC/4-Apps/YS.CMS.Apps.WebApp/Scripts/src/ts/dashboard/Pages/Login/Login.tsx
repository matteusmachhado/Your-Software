import React, { Component } from 'react';
import { Button } from './../../../components/Forms/index';
import Loader from './../../../components/Loader/Loader';
import './Login.css';
import iziToast from 'izitoast';

type Props = {
    Value: string;
}

type State = {
    UserName: string;
    Password: string
    IsPersistent: boolean
}

export default class Login extends Component<Props, State>{

    constructor(props: Props) {
        super(props);
        this.state = {
            UserName: '',
            Password: '',
            IsPersistent: false
        }
    }

    logar = async () => {
        console.clear();
        await fetch('http://localhost:5000/api/v1.0/login/', {
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
                        message: 'Usuário autenticado.',
                    });
                    this.setState({
                        UserName: '',
                        Password: '',
                        IsPersistent: false
                    });
                    window.location.href = "https://localhost:44336/#/";  
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
                        <input type="text" className="form-control" placeholder="Nome de usuário" value={this.state.UserName} onChange={(e: React.ChangeEvent<HTMLInputElement>) => this.setState({ UserName: e.target.value })} />
                    </div>
                    <div className="form-label-group">
                        <input type="Password" name="Password" className="form-control" placeholder="Senha" value={this.state.Password} onChange={(e: React.ChangeEvent<HTMLInputElement>) => this.setState({ Password: e.target.value })} />
                    </div>
                    <label className="btn-checked">
                        <input type="checkbox" name="IsPersistent" checked={this.state.IsPersistent} onClick={() => this.setState({ IsPersistent: !this.state.IsPersistent })} /> Lembrar-me
                    </label>    
                    <Button value="Login" icon="fa fa-sign-out" onClick={() => this.logar()} />
                </div>
            </form>
        );
    }  
}