import React, { Component } from 'react';
import Loading from './Loading'

export class AspNetTest extends Component {
    static displayName = AspNetTest.name;

    constructor(props) {
        super(props);
        this.state = { foods: [], loading: true };
    }

    componentDidMount() {
        this.getSampleFoods();
    }

    static renderFoodsTable(foods) {
        console.log(foods);
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">

                <thead>
                    <tr>
                        <th>Name</th>
                        <th>ServingSize</th>
                        <th>Protein</th>
                        <th>Calories</th>
                    </tr>
                </thead>

                <tbody>
                    {foods.map((food) => (
                        <tr>
                            <td>{food.name}</td>
                            <td>{food.serving_size_g}</td>
                            <td>{food.protein_g}</td>
                            <td>{food.calories}</td>
                        </tr>
                    )
                    )}
                </tbody>
            </table>
        );
    }

    async getSampleFoods() {
        const url = "https://localhost:7144/food";
        fetch(url, {
            method: "GET"
        })
            .then(resp => resp.json())
            .then(data => this.setState({ foods: data, loading: false }))
    }


    render() {
        let contents = this.state.loading
            ? <Loading />
            : AspNetTest.renderFoodsTable(this.state.foods);

        return (
            <div>
                <h1 id="tabelLabel" >This be da foods</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
