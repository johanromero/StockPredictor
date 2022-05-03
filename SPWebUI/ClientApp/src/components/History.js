import React, { Component } from 'react';

export class History extends Component {


    constructor(props) {
        super(props);
        this.state = { history: [], loading: true };
    }

    componentDidMount() {
        this.populateStockData();
    }

    static renderHistoryData() {
        return (
            <div class="box">
                <table class="table is-hoverable is-striped is-fullwidth">
                    <thead>
                        <tr>
                            <th id="date"><a asp-action="History" asp-controller="User" asp-route-sort="CreationDate"><abbr title="Creation Date">Date</abbr></a></th>
                            <th id="companyName"><a asp-action="History" asp-controller="User" asp-route-sort="CompanyName">Company Name</a></th>
                            <th id="ticker"><a asp-action="History" asp-controller="User" asp-route-sort="Ticker"><abbr title="Ticker">Tkr</abbr></a></th>
                            <th id="1d"><a asp-action="History" asp-controller="User" asp-route-sort="OneDayPred"><abbr title="One Day">1d</abbr></a></th>
                            <th id="1w"><a asp-action="History" asp-controller="User" asp-route-sort="OneWeekPred"><abbr title="One Week">1w</abbr></a></th>
                        </tr>
                    </thead>
                    <tbody>

                        {Predictions.map(item =>
                            <tr>
                                <td>{item.CreationDate}</td>
                                <td>{item.CompanyName}</td>
                                <td>{item.Ticker}</td>
                                <td>{item.OneDayPred}</td>
                                <td>{item.OneWeekPred}</td>
                            </tr>
                        )};

                    </tbody>
                </table>
            </div>
        );
    }


    render() {


        return (
            <section class="section">
                <div class="container">



                    <div class="box">
                        <table class="table is-hoverable is-striped is-fullwidth">
                            <thead>
                                <tr>
                                    <th id="date"><a href="/User/History/CreationDate"><abbr title="Creation Date">Date</abbr></a></th>
                                    <th id="companyName"><a href="/User/History/CompanyName">Company Name</a></th>
                                    <th id="ticker"><a href="/User/History/Ticker"><abbr title="Ticker">Tkr</abbr></a></th>
                                    <th id="1d"><a href="/User/History/OneDayPred"><abbr title="One Day">1d</abbr></a></th>
                                    <th id="1w"><a href="/User/History/OneWeekPred"><abbr title="One Week">1w</abbr></a></th>
                                    <th id="1mo"><a href="/User/History/OneMonthPred"><abbr title="One Month">1mo</abbr></a></th>
                                    <th id="3mo"><a href="/User/History/ThreeMonthPred"><abbr title="Three Month">3mo</abbr></a></th>
                                    <th id="1yr"><a href="/User/History/OneYearPred"><abbr title="One Year">1yr</abbr></a></th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>


                </div>
            </section>
        );
    }

    async populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}



