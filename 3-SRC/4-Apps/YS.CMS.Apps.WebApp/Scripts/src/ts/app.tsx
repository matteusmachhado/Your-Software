import * as React from 'react';
import * as ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.css';
import { hot } from 'react-hot-loader';
import { AppComponents } from './dashboard/components-render';

var App = hot(module)(AppComponents);

ReactDOM.render(<App />, document.querySelector('#app'));