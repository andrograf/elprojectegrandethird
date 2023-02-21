import React, { Component } from 'react';
import Loading from './Loading'

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
            <p>{foods}</p>
        );
      }

 async getSampleFoods() {
     const url = "https://community-healthcaregov.p.rapidapi.com/api/glossary.json";
      fetch(url, {
          method: "GET",
          withCredentials: true,
          headers: {
              'X-RapidAPI-Key': '8a879b7c89msh4af8b5e2f743eacp1283c9jsn070543610b0b',
              'X-RapidAPI-Host': 'community-healthcaregov.p.rapidapi.com'
          }
      })
          .then(resp => resp.json())
          .then(data => this.setState({ foods: data, loading: false }))
    }


    render() {
        let contents = this.state.loading
            ? <Loading />
            : FetchData.renderFoodsTable(this.state.foods);

        return (
            <div>
                <h1 id="tabelLabel" >This be da foods</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
