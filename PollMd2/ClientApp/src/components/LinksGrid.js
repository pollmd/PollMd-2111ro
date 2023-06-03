import React, { Component } from 'react';

export class LinksGrid extends Component {
    static displayName = LinksGrid.name;

  constructor(props) {
      super(props);
      this.state = { polls: [], loading: true };
    }

  componentDidMount() {
      this.populatePollsList();
    }

    static renderList(polls) {
        return (<>
            <br />
            <br />
            <div class="row" style={{ background: '#aaaaaa', color: 'white' }} >
                <div class="col-md-3">
                    Poll
                </div>
                <div class="col-md">
                    Nr. Accesari
                </div>
                <div class="col-md">
                    User
                </div>
                <div class="col-md">
                    User
                </div>
            </div>
            <div class="container">
                {polls.map(poll =>
                    <div key={poll.id} class="row">
                        <div class="col-md-3">
                            <a href={"/polls?id=" + poll.id}>{poll.text}</a>
                        </div>
                        <div class="col-md">
                            10
                        </div>
                        <div class="col-md">
                            {poll.userId}
                        </div>
                        <div class="col-md">
                            {poll.creationDate}
                        </div>
                    </div>
                )}
            </div>
        </>);
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : LinksGrid.renderList(this.state.polls);

        return (
            <div>
                {contents}
            </div>
        );
  }


    async populatePollsList() {
        const response = await fetch('questions/getquestions');
        const data = await response.json();
        this.setState({ polls: data, loading: false });
    }

}
