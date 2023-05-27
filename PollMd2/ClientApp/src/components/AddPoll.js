import React, { Component } from 'react';

export class AddPoll extends Component {
  static displayName = AddPoll.name;

  constructor(props) {
    super(props);
    this.state = { };
  }

    render() {
        return (
            <>
                <h1>Add poll</h1>
                <form action="questions/addpoll" method="POST">
                    <textarea id="questiontext" name="questiontext" rows="4" cols="50" />
                    <br/>
                    <input type="text" id="option1" name="option1" />
                    <br/>
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
