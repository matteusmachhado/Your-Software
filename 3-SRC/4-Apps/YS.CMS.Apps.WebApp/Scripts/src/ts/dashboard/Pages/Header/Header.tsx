import React, { StatelessComponent } from 'react';
import { Link } from "react-router-dom";
import './Header.css';

export const Header: StatelessComponent<{}> = () => {
    return (
        <div>
            <div className="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-nav-custom border-bottom box-shadow">
                <h5 className="my-0 mr-md-auto nav-title-custom">Your Software</h5>
                <nav className="my-2 my-md-0 mr-md-3">
                    <a className="p-2" href="#">HOME</a>
                    <a className="p-2" href="#">TECNOLOGIAS</a>
                    <a className="p-2" href="#">CRIAR SITE</a>
                    <a className="p-2" href="#">SOBRE</a>
                    <Link to="/Login"><i className="fa fa-sign-out p-2 icon-header"></i></Link>
                    <Link to="/Register"><i className="fa fa-user-plus icon-header"></i></Link>
                </nav>
            </div>
        </div>
    );
}