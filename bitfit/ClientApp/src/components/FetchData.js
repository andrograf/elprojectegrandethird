import React, { Component } from 'react';
import loading from '../images/loading.gif'

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { foods: [], loading: true };
  }

  componentDidMount() {
    this.getSampleFoods();
  }

    static renderFoodsTable(foods) {
        console.log(foods.items);
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
          {foods.items.map((food) => (
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

  render() {
    let contents = this.state.loading
        ? <p><img src={loading } alt="poopies"/></p>
      : FetchData.renderFoodsTable(this.state.foods);

    return (
      <div>
        <h1 id="tabelLabel" >This be da foods</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

 async getSampleFoods() {
      const url = "https://api.calorieninjas.com/v1/nutrition?query=apple";
      fetch(url, {
          method: "GET",
          withCredentials: true,
          headers: {
              "X-Api-Key": "Psij6QAOOFNwBBxyV91U4w==n1GEtDahReZRqJfI",
          }
      })
          .then(resp => resp.json())
          .then(data => this.setState({ foods: data, loading: false }))
  }
}
