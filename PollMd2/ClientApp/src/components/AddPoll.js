import React, { Component } from 'react';

export class AddPoll extends Component {
    static displayName = AddPoll.name;

    constructor(props) {
        super(props);
        this.state = {
            submittedQuestions: [],
        };
    }

    handleSubmit = (event) => {
        event.preventDefault();
        const questionText = event.target.questiontext.value;
        const updatedQuestions = [...this.state.submittedQuestions, questionText];
        this.setState({ submittedQuestions: updatedQuestions });
        event.target.reset();

        const queryParams = new URLSearchParams();
        queryParams.set('questions', JSON.stringify(updatedQuestions));
        this.props.history.push(`/poll?${queryParams.toString()}`);
    };

    render() {
        return (
            <>
                <h1>Add poll</h1>
                <div>
                    {this.state.submittedQuestions.length > 0 && (
                        <div>
                            <h2>Submitted Questions:</h2>
                            <ul>
                                {this.state.submittedQuestions.map((question, index) => (
                                    <li key={index}>{question}</li>
                                ))}
                            </ul>
                        </div>
                    )}
                </div>
                <form action="/poll" method="POST" onSubmit={this.handleSubmit}>
                    <textarea id="questiontext" name="questiontext" rows="4" cols="50" />
                    <br />
                    <input type="text" id="option1" name="option1" />
                    <br />
                    <input type="text" id="option2" name="option2" />
                    <br />
                    <input type="text" id="option3" name="option3" />
                    <br />
                    <input type="submit" />
                </form>
            </>
        );
    }
}
