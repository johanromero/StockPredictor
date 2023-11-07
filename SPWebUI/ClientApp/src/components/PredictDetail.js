import React from 'react';



const PredictDetail = (prop) => {
        
    return (
            <div className="column is-four-fifths">
                                    <table className="table is-striped is-fullwidth">
                                        <thead>
                                            <tr>
                                                <th id="date"><abbr title="Creation Date">Date</abbr></th>
                                                <th id="ticker"><abbr title="Ticker">Symbol</abbr></th>
                                                <th id="1m"><abbr title="One Month">1 Month</abbr></th>
                                                <th id="6m"><abbr title="Six Months">6 Months</abbr></th>
                                                <th id="1y"><abbr title="One Year">1 year</abbr></th>
                                                <th id="5y"><abbr title="Five Years">5 years</abbr></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                        <td>{ prop.data.date }</td>
                                        <td>{prop.data.ticker }</td>
                                        <td>${prop.data.oneMonth }</td>
                                        <td>${prop.data.sixMonths }</td>
                                        <td>${prop.data.oneYear }</td>
                                        <td>${prop.data.fiveYears }</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
    )
}


export default PredictDetail






          