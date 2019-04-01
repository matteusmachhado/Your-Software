import React from 'react';
import ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.css';
import { hot } from 'react-hot-loader';
import { AppComponents } from './basic/components/components-render'; // >_ Template Basic

var App = hot(module)(AppComponents);

ReactDOM.render(<App />, document.querySelector('#template'));