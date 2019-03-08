import React from "react";
import ReactDOM from "react-dom";
import List from "./List";
var app = document.getElementById("app");
ReactDOM.render(
    <List />,
    app
);
//the next line is necessary for hot reloading to work
module.hot.accept();