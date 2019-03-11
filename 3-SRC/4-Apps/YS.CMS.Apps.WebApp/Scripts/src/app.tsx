import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { hot } from 'react-hot-loader';
import { AppComponents } from './components-render';

var App = hot(module)(AppComponents);

ReactDOM.render(<App />, document.querySelector('#app'));