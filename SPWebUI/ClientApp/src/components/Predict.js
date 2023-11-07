import React, { Component } from 'react';
import PredictDetail from '../components/PredictDetail';
import Chart from '../components/Chart'

export class Predict extends Component {
   

    constructor(props) {
        super(props);
        this.state = {
            isError: false,
            isSubmitting: false,
            values: {
                Ticker: "MSFT"
            },
        };
       
    }

    handleInputChange = e => this.setState({
        values: {
            Ticker: e.target.value
        }
    });

    submitForm = async e => {
        e.preventDefault();
        console.log('Log body'+this.state.values);
        const apiUrl = "https://localhost:44395/api/predictor";
            this.setState({ isSubmitting: true });
            const res = await fetch(apiUrl, {
                method: "POST",
                body: JSON.stringify(this.state.values),
                headers: {
                    "Content-Type": "application/json"
                }               
            });
        this.setState({ isSubmitting: false }); 
        const data = await res.json();
        const plotData = data && [
            ["Date", this.state.values.Ticker],
            [30, data.oneMonth],
            [180, data.sixMonths],
            [360, data.oneYear],
            [360*5, data.fiveYears],
        ];
        this.setState({ response: data, plotData: plotData });
            !data.hasOwnProperty("error")
                ? this.setState({ message: data.success })
                    : this.setState({ message: data.error, isError: true });
        //setTimeout(
        //    () =>
        //        this.setState({
        //            isError: false,
        //            message: "",
        //            values: { symbol: "" }
        //        }),
        //    1600
        //);
    }

    

    render() {

       
        return (
            <section className="section">
                <div className="container">
                    <div className="box">
                        <div className="columns is-vcentered">
                            <div className="column is-one-fifth">
                                <form 
                                    method="post"
                                    noValidate="novalidate">
                                    <div className="field">
                                    <label className="label" htmlFor="Symbol">Symbol</label>
                                    {/*<div className="control">*/}
                                    {/*        <input*/}
                                    {/*            className="input"*/}
                                    {/*            value={this.state.values.Ticker || ''}*/}
                                    {/*            onChange={this.handleInputChange}*/}
                                    {/*            data-val="true"*/}
                                    {/*            data-val-maxlength="Must be less than 5 characters"*/}
                                    {/*            data-val-maxlength-max="5"*/}
                                    {/*            data-val-required="The Symbol field is required."*/}
                                    {/*            id="symbol"*/}
                                    {/*            maxLength="5"*/}
                                    {/*            name="Symbol"*/}
                                    {/*            type="text"*/}
                                    {/*        />*/}
                                    {/*    </div>*/}

                                        <select id="symbol" name="cars"
                                            onChange={this.handleInputChange}
                                        >
                                            <option value="MSFT">Microsoft</option>
                                            <option value="AAPL">Apple</option>
                                            <option value="AMZN">Amazon</option>
                                        </select>

                                    </div>
                                    <div className="control">
                                        <button type="submit" onClick={this.submitForm}
                                            className="button is-primary" id="getTicker">Make Prediction</button>
                                    </div>                                   
                                </form>
                            </div>
                            <div className="column is-four-fifths">
                                {this.state.response ?
                                    <PredictDetail data={this.state.response} />
                                    : <div></div>}
                                    </div>

                                </div>
                                    {this.state.plotData ?
                                        <Chart 
                                            data={this.state.plotData} />
                                        : <div>Loading...</div>}
                                </div>
                </div>
            </section>
        );
    }
}






          