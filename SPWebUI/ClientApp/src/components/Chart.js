import { Chart } from "react-google-charts";
import React from 'react';

export const options = {
    title: "Stock predictor ",
    hAxis: { title: "Prediction", titleTextStyle: { color: "#333" } },
    vAxis: { minValue: 0 },
    legend: { position: "bottom" },
  };

const charts = (prop) => {
    return (
        <Chart
            chartType="AreaChart"
            data={prop.data}
            width="100%"
            height="400px"
            options={options}
        />
    )
}
export default charts