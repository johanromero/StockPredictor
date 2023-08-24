import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <section class="section">
            <div class="container">

                <div class="box">
                    <div class="columns is-centered">
                        <div class="hero">
                            <h1 class="hero-body title">Welcome to Stock Predictor, a predictive stock tool from ML.NET</h1>
                        </div>
                    </div>
                    <h2 class="field">Simply click "Predict" at the top of the page and write in the desired Stock symbol you wish to try to predict. 
                        Our machine learning algorithm will then look at the most recent data for that stock and predict the future of that stock for the next year.</h2>

                </div>

            </div>
        </section>
    );
  }
}
 