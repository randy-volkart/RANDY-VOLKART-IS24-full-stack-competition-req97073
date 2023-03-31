import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { data: [], loading: true };
    }

    componentDidMount() {
        this.populateProductData();
    }

    static renderProductsTable(products) {
        //console.log(products.count);
        //console.log(products);
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Product Number</th>
                        <th>Product Name</th>
                        <th>Scrum Master</th>
                        <th>Product Owner</th>
                        <th>Developer Names</th>
                        <th>Start Date</th>
                        <th>Methedology</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(products =>
                        <tr key={products.productNumber}>
                            <td>{products.productNumber}</td>
                            <td>{products.productName}</td>
                            <td>{products.scrumMaster}</td>
                            <td>{products.productOwner}</td>
                            <td>{products.developerNames.map(item => <p> { item } </p>)}</td>
                            <td>{products.startDate}</td>
                            <td>{products.methodology}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading Products...</em></p>
            : Home.renderProductsTable(this.state.products);

        let count = 0; 
        const myLength = (array) => {
            for (let i in array) {
                if (Array.isArray(array[i])) {
                    myLength(array[i]);
                } else {
                    count++;
                }
            }
        }
        myLength(this.state.products);

        console.log(this.state.products);
        console.log(count);
        return (
          <div>
            <p>Product Count: {count}</p>
            {contents}
          </div>
        );
    }


    async populateProductData() {
        const response = await fetch('weatherforecast')
            .catch(error => console.log(error));
        const data = await response.json();
        console.log(data);
        this.setState({ products: data, loading: false });
    }
}
