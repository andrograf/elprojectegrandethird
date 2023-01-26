import React, { Component } from 'react';

export class Recipes extends Component {
    static displayName = Recipes.name;

    constructor(props) {
        super(props);
        this.state = { recipes: [], loading: true };
    }

    componentDidMount() {
        this.getSampleRecipes();
    }

    static renderRecipes(recipes) {
        return (
            <div className="container-fluid" >
                {recipes.map((recipe) => (
                <div className='card'>
                    <div className="card-header">{recipe.title}</div>
                        <div className="card-body">
                            <ul>
                            <li>{recipe.ingredients}</li>
                            <li>{recipe.servings}</li>
                            <li>{recipe.instructions}</li>
                            </ul>
                    </div>
                </div>
                ))}
                </div>
        );
            
    }

    async getSampleRecipes() {
        const url = "https://localhost:7144/recipe";
        fetch(url, {
            method: "GET",
        })
            .then(resp => resp.json())
            .then(data => this.setState({ recipes: data, loading: false }))
    }


    render() {
        let contents = Recipes.renderRecipes(this.state.recipes);

        return (
            <div>
                <h1 id="tabelLabel" >This be da recipes m8</h1>
                <p>This component demonstrates fetching recipes from the server.</p>
                {contents}
            </div>
        );
    }
}
