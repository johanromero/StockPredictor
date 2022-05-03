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
                            <h1 class="hero-body title">Welcome to Stock Predictor, a predictive stock tool from MLTT.NE</h1>
                        </div>
                    </div>
                    <h2 class="field">To see the power of our tool in action, simply click "Predict" at the top of the page and write in the desired Stock symbol you wish to try to predict. Our machine learning algorithm will then look at the most recent data for that stock and predict the future of that stock for the next year.</h2>
                    <h2 class="field">Unregistered users can make predictions and view any predictions made by other unregistered users, but sign up or log in to save your predictions to your account, giving you additional privacy to use the prediction for youself. Plus, any logged in user will get to see extra information when they make a prediction. Between a powerful and interactive plot of your prediction and related news articles populated based on your prediction, you'll be one step ahead of everybody else, prepared for anything.</h2>
                </div>

            </div>
        </section>
    );
  }
}
 