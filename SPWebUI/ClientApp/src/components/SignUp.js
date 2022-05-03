import React, { Component } from 'react';

export class Predict extends Component {


    constructor(props) {
        super(props);
        this.state = { symbol: '' };

    }

    handleSubmit() {

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
                        Please enter your desired credentials below and start being able to:
                        <div class="columns">
                            <ul class="is-offset-1 column" style="list-style-type:disc;">
                                <li>
                                    Keep your predictions secret only to yourself
                                </li>
                                <li>
                                    View a visual representation of your prediction after it is made
                                </li>
                                <li>
                                    See the news related to your prediction to further inform your investment
                                </li>
                            </ul>
                        </div>
                        <form action="/User/SignUp" method="post" novalidate="novalidate">      <div class="field">
                            <label class="label" for="Name">Name</label>
                            <div class="control">
                                <input class="input" data-val="true" data-val-maxlength="Must be less than 50 characters" data-val-maxlength-max="50" data-val-minlength="Must have at least one character" data-val-minlength-min="1" data-val-required="The Name field is required." id="Name" maxlength="50" name="Name" placeholder="eg. John" type="text" value="" />
                         </div>
                                <p class="help is-danger"><span class="field-validation-valid" data-valmsg-for="Name" data-valmsg-replace="true"></span></p>
                            </div>
                            <div class="field">
                                <label class="label" for="Username">Username</label>
                                <div class="control">
                                    <input class="input" data-val="true" data-val-maxlength="Must be less than 50 characters" data-val-maxlength-max="50" data-val-minlength="Must be at least 4 characters long" data-val-minlength-min="4" data-val-required="The Username field is required." id="Username" maxlength="50" name="Username" placeholder="Enter your desired username" type="text" value="" />
                        </div>
                                    <p class="help is-danger"><span class="field-validation-valid" data-valmsg-for="Username" data-valmsg-replace="true"></span></p>
                                </div>
                                <div class="field">
                                    <label class="label" for="Password">Password</label>
                                    <div class="control">
                                        <input class="input" data-val="true" data-val-maxlength="Must be less than 50 characters" data-val-maxlength-max="50" data-val-minlength="Must be at least 4 characters long" data-val-minlength-min="4" data-val-required="The Password field is required." id="Password" maxlength="50" name="Password" placeholder="Enter desired password" type="password" />
                                     </div>
                                        <p class="help is-danger"><span class="field-validation-valid" data-valmsg-for="Password" data-valmsg-replace="true"></span></p>
                                    </div>
                                    <div class="field">
                                        <label class="label" for="Confirm">Confirm Password</label>
                                        <div class="control">
                                            <input class="input" data-val="true" data-val-maxlength="Must be less than 50 characters" data-val-maxlength-max="50" data-val-minlength="Must be at least 4 characters long" data-val-minlength-min="4" data-val-required="The Password field is required." id="Confirm" maxlength="50" name="Confirm" placeholder="Confirm password" type="password" />
                                    </div>
                                            <p class="help is-danger"><span class="field-validation-valid" data-valmsg-for="Confirm" data-valmsg-replace="true"></span></p>
                                        </div>
                                        <div class="control">
                                            <button type="submit" class="button is-primary" id="signup">Sign Up</button>
                                        </div>
                                        <input name="__RequestVerificationToken" type="hidden" value="CfDJ8Fi1H8UbxnlMvUASl2XwYkvzISJZHLeNNVpfmcRKMnD5jUl69cL7XMgim5fbGYCLDB87RA73_S_ltgrcAn0i91UW60xvlkxRoOzY1droULUUykfmweUjdCceHWpmmVMntHmEnO6uXhQThY8wfcfj_M4" /></form></div>

                                </div>
             </section>

        );
    }
}





