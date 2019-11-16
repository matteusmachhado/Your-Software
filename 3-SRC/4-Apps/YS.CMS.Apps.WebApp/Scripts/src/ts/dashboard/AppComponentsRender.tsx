import React, { StatelessComponent } from "react";
import { HashRouter, Route, Switch } from 'react-router-dom';
import { App } from './Pages/App';
import { Home, Login, Register } from './Pages/index';

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
