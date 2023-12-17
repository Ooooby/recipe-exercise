import React, { Component } from 'react';

export class FetchRecipes extends Component {
  static displayName = FetchRecipes.name;

  constructor(props) {
    super(props);
    this.state = { recipes: [], loading: true };
  }

  componentDidMount() {
    this.populateRecipeData();
  }

  static renderRecipesTable(recipes) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {recipes.map(recipe =>
            <tr key={recipe.id}>
              <td>{recipe.name}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchRecipes.renderRecipesTable(this.state.recipes);

    return (
      <div>
        <h1 id="tabelLabel" >Recipes</h1>
        {contents}
      </div>
    );
  }

  async populateRecipeData() {
    const response = await fetch('recipe');
    const data = await response.json();
    this.setState({ recipes: data, loading: false });
  }
}
