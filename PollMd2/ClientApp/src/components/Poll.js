import React, { Component } from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar';

export class Poll extends Component {
  static displayName = Poll.name;

  constructor(props) {
    super(props);
    this.state = { polls: [], loading: true };
  }

  componentDidMount() {
    this.populatePollData();
  }

  static renderPollsForm(polls) {
    return (
        <div>
            <h1>{polls.text}</h1>
            <form action="questions/vote" method="POST">
            {polls.answers.map(poll =>
                <div key={poll.id}>
                    <input type="radio" value={poll.id} name="optionid" />
                    <label>{poll.text}</label>
                    <ProgressBar striped variant="info" now={20} />
                </div>
                )}
                <input type="submit"/>
            </form>
        </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Poll.renderPollsForm(this.state.polls);

    return (
      <div>
        {contents}
      </div>
    );
  }

    async populatePollData() {
        const response = await fetch('questions?id=1');
        const data = await response.json();
        this.setState({ polls: data, loading: false });
  }
}
