import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Media } from 'reactstrap';
import { Link } from 'react-router-dom';
import logo from './logStockPredictor.png';

export class Header extends Component {

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
        }

        render() {
            return (
                <header>
                    <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                        <Container>
                            <Media object src={logo} alt="Ascend" width="112" height="28" />
                            <NavbarBrand tag={Link} to="/">Stock Predictor</NavbarBrand>
                            <NavbarBrand tag={Link} to="/">History</NavbarBrand>
                            <NavbarBrand tag={Link} to="/">Predict</NavbarBrand>
                            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                                <ul className="navbar-nav flex-grow">
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/">Sign Up</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/counter">Login in</NavLink>
                                    </NavItem>
                                </ul>
                            </Collapse>
                        </Container>
                    </Navbar>
                </header>
            );
        }
    }


