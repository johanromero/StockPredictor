import React, { Component } from 'react';

export class PredictDetail extends Component {   

    constructor(props) {
        super(props);
        this.state = {
            data: props.data
        };
        console.log(this.state.data);
    }

    render() {
        
        return (
             <div className="column is-four-fifths">
                                        <table className="table is-striped is-fullwidth">
                                            <thead>
                                                <tr>
                                                    <th id="date"><abbr title="Creation Date">Date</abbr></th>
                                                    <th id="companyName">Company Name</th>
                                                    <th id="ticker"><abbr title="Ticker">Tkr</abbr></th>
                                                    <th id="1d"><abbr title="One Month">1Month</abbr></th>
                                                    <th id="1w"><abbr title="Six Months">6Month</abbr></th>
                                                    <th id="1mo"><abbr title="One Year">1y</abbr></th>
                                                    <th id="3mo"><abbr title="Five Years">5y</abbr></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                            <td>{ this.state.data.creationDate }</td>
                                            <td>{this.state.data.ticker }</td>
                                            <td>{this.state.data.ticker }</td>
                                            <td>${this.state.data.OneMonth }</td>
                                            <td>${this.state.data.SixMonths }</td>
                                            <td>${this.state.data.OneYear }</td>
                                            <td>${this.state.data.FiveYears }</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
        );
    }
}






          