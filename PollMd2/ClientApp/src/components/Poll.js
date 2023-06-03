import React, { Component } from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar';
import { LinksGrid } from './LinksGrid';

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
              <iframe id="iframep" name="iframep" style={{ display: 'none' }} ></iframe>
            <form action="questions/vote" method="POST" target="iframep">
            {polls.answers.map(answ =>
                <div key={answ.id}>
                    <input type="radio" value={answ.id} name="optionid" />
                    <label>{answ.text} - <i>{ answ.votes }</i></label>
                    <ProgressBar striped variant="info" now={answ.votes} />
                </div>
                  )}
                <br />
                  <input type="submit" />
              </form>
              <LinksGrid/>
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
        const params = new URLSearchParams(window.location.search);
        let pollId = params.get("id")
        if(pollId==null) pollId=1
        const response = await fetch('questions?id=' + pollId);
        const data = await response.json();
        this.setState({ polls: data, loading: false });
    }
}
