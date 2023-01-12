import React, { Component } from 'react';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
            <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                <div className="container-fluid">
                    <div className="nav-card">
                        <a className="navbar-brand" href="/" asp-area="" asp-controller="Home" asp-action="Index">BitFit</a>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                            aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                    </div>
                    <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                        <ul className="navbar-nav flex-grow-1">
                            <li className="nav-item">
                                <div className="nav-card">
                                    <a className="nav-link text-dark" href="/recipes" asp-area="" asp-controller="Recipe" asp-action="Recipes">Recipes</a>
                                </div>
                            </li>
                            <li className="nav-item">
                                <div className="nav-card">
                                    <a className="nav-link text-dark" href="/foods" asp-area="" asp-controller="Foods" asp-action="Index">Foods</a>
                                </div>
                            </li>
                            <li className="nav-item">
                                <div className="nav-card">
                                    <a className="nav-link text-dark" href="/dashboard" asp-area="" asp-controller="Home" asp-action="Index">Dashboard</a>
                                </div>
                            </li>
                            <li className="nav-item">
                                <div className="nav-card">
                                    <a className="nav-link text-dark inactive-link" href="/activity" asp-area="" asp-controller="Home" asp-action="Index">Activity</a>
                                </div>
                            </li>
                            <li className="nav-item">
                                <div className="nav-card">
                                    <a className="nav-link text-dark inactive-link" href="/login" asp-area="" asp-controller="Home" asp-action="Index">Login</a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
      </header>
    );
  }
}
