import * as React from "react";
import * as reactDOM from "react-dom";
import List from "./List";

import { hot } from 'react-hot-loader';

var Teste = hot(module)(List);

var App = () => <Teste />;

reactDOM.render(<App />, document.querySelector('#app'));