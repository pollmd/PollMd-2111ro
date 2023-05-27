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
          <>
            <h1>{polls.text}</h1>
            <form action="questions/vote" method="POST">
            {polls.answers.map(answ =>
                <div key={answ.id}>
                    <input type="radio" value={answ.id} name="optionid" />
                    <label>{answ.text} - <i>{ answ.votes }</i></label>
                    <ProgressBar striped variant="info" now={answ.votes} />
                </div>
                  )}
                <br />
                <input type="submit"/>
            </form>
        </>
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
