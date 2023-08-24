import { Chart } from "react-google-charts";
import React, { Component }  from 'react';

export const options = {
    title: "Stock predictor function",
    curveType: "function",
    legend: { position: "bottom" },
  };

const charts = (prop) => {
    return (
        <Chart
            chartType="LineChart"
            data={prop.data}
            width="100%"
            height="400px"
            options={options}
        />
    )
}
export default charts