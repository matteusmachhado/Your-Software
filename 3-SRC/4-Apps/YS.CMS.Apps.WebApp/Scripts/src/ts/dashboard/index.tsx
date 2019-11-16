import React from 'react';
import ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.css';
import 'izitoast/dist/css/iziToast.min.css';
import { hot } from 'react-hot-loader';
import { AppComponentsRender } from './AppComponentsRender';

var App = hot(module)(AppComponentsRender);

ReactDOM.render(<App />, document.querySelector('#dashboard'));