import React, { Component } from 'react';
import Loading from './Loading'
import './Articles.css'

export class Articles extends Component {
    static displayName = Articles.name;

    constructor(props) {
        super(props);
        this.state = { articles: [], loading: true };
    }

    componentDidMount() {
        this.getSampleArticles();
    }

    static renderArticles(articles) {
        return (
            <span>
                {articles.map((article) => (
                    <div className="articleBackground">
                    <section className="articleText">{article}</section>
                    </div>
                ))
            }
            </span>
        );
    }

    getSampleArticles() {
        const data = [
            "This is a small article, with not that much text... just a little bit of text. Maybe... Sometimes.",
            "The guinea pig or domestic guinea pig (Cavia porcellus), also known as the cavy or domestic cavy (/ˈkeɪvi/), is a species of rodent belonging to the genus Cavia in the family Caviidae. Despite their common name, guinea pigs are not native to Guinea, nor are they closely related biologically to pigs, and the origin of the name is still unclear. They originated in the Andes of South America. Studies based on biochemistry and hybridization suggest they are domesticated animals that do not exist naturally in the wild, descendants of a closely related cavy species such as C. tschudii.[2][3] They were originally domesticated as livestock for a source of meat, and are still consumed in some parts of the world.",
            "Way too long Article:Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results.Insanity is doing the same thing over and over and expecting different results."];
        this.setState({ articles: data, loading: false });
    }


    render() {
        let contents = this.state.loading
            ? <Loading />
            : Articles.renderArticles(this.state.articles);

        return (
            <div className="articleContainer">
                <h1 id="articleContainer" >This be da artikels, mon.</h1>
                <p>This component demonstrates article stlye.</p>
                {contents}
            </div>
        );
    }
}
