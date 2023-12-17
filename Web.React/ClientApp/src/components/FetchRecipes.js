import React, { Component } from 'react';

export class FetchRecipes extends Component {
  static displayName = FetchRecipes.name;

  constructor(props) {
    super(props);
    this.state = { recipes: [], loading: true, searchTerm: '' };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.populateRecipeData();
  }

  handleInputChange(event) {
    this.setState({searchTerm: event.target.value});
  }

  async handleSubmit(event) {
    event.preventDefault();
    await this.populateRecipeData(this.state.searchTerm);
  }

  static renderRecipesTable(recipes) {
    return (
      <table className="table table-striped mt-2" aria-labelledby="tabelLabel">
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
          <h1 id="tabelLabel">Recipes</h1>
          <form onSubmit={this.handleSubmit} className="row mt-2">
            <div className="col-4">
              <input type="text" className="form-control"
                     value={this.state.searchTerm}
                     onChange={this.handleInputChange}/>
            </div>
            <div className="col-1">
              <button type="submit" className="btn btn-primary">Search</button>
            </div>
          </form>
          {contents}
        </div>
    );
  }

  async populateRecipeData() {
    const response = await fetch(`recipe?searchTerm=${this.state.searchTerm}`);
    const data = await response.json();
    this.setState({recipes: data, loading: false});
  }
}
