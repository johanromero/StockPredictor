import React, { Component } from 'react';

export class Predict extends Component {
   

    constructor(props) {
        super(props);
        this.state = { symbol: '', value: 0 };
       
    }

    handleSubmit() {
        fetch('/api/PREDICT')
            .then(res => {
                return res.json();
            })
            .then(res => {
                this.setState({
                    symbol: res.symbol,
                    value: res.value
                })
            });
    }

    predict(e) {
        return fetch('/api/PREDICT')
            .then(response => response.json())
            .then(data => console.log(data)); 
    }

    handleChange(event) {
        this.setState({
            submit: event.target.value
        });
    }

   

    render() {
        return (
            <section class="section">
                <div class="container">
                    <div class="box">
                        <div class="columns is-vcentered">
                            <div class="column is-one-fifth">
                                <form onSubmit={this.handleSubmit()}  novalidate="novalidate">
                                    <div class="field">
                                    <label class="label" for="Symbol">Symbol</label>
                                    <div class="control">
                                            <input class="input" value={this.state.symbol} data-val="true" data-val-maxlength="Must be less than 5 characters" data-val-maxlength-max="5" data-val-required="The Symbol field is required." id="symbol" maxlength="5" name="Symbol" type="text" value={this.satate.value} />
                                     </div>
                                        <p class="help is-danger"><span class="field-validation-valid" data-valmsg-for="Symbol" data-valmsg-replace="true"></span></p>
                                    </div>
                                    <div class="control">
                                        <button type="submit" class="button is-primary" id="getTicker">Make Prediction</button>
                                    </div>
                                    <input name="__RequestVerificationToken" type="hidden" value="CfDJ8Fi1H8UbxnlMvUASl2XwYkupmJgLUn7GcT2ICxZ6BgjUcrJbZT6C0GC75ERpoS9bzXNYzD1grpLwj3CsxogHuMGeTMJWo0N_w1SSNAhzIsEikYbVZ6_2-GDbmWoDmRiJiCXpjuJMDtgd2lwLKsQqmyE" />
                                        </form>
                                    </div>
                                    <div class="column is-four-fifths">
                                    </div>
                                        </div>
                            </div>



                        </div>
            </section>
        );
    }
}






          