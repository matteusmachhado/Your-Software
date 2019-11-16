import React, { StatelessComponent } from "react";
import { HashRouter, Route, Switch } from 'react-router-dom';
import { App } from './Pages/App';
import Login from './Pages/Login/Login';
import Register from './Pages/Register/Register';
import { Home } from './Pages/index';

export const AppComponentsRender: StatelessComponent<{}> = () => {
    return (
        <HashRouter>
            <div>
                <Route component={App} />
                <Switch>
                    <Route exact path="/Login" component={Login} />
                    <Route path="/Register" component={Register} />
                    <Route path="/" component={Home} />
                </Switch>
            </div>
        </HashRouter>
    );
}
