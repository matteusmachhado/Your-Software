import React from 'react';
import ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.css';
import { hot } from 'react-hot-loader';
import { AppComponents } from './components/components-render';

var App = hot(module)(AppComponents);

ReactDOM.render(<App />, document.querySelector('#dashboard'));