import React, { Component } from 'react';

export class LinksGrid extends Component {
    static displayName = LinksGrid.name;

  constructor(props) {
    super(props);
  }

  render() {
      return (
          <>
              <br />
              <br />
              <div class="container">
                  <div class="row" style={{ background: '#aaaaaa', color:'white' }} >
                      <div class="col-sm">
                          Poll
                      </div>
                      <div class="col-sm">
                          Nr. Accesari
                      </div>
                      <div class="col-sm">
                          User
                      </div>
                      <div class="col-sm">
                          User
                      </div>
                  </div>
                  <div class="row">
                      <div class="col-sm">
                          <a href="/polls?id=1">Messi sau Ronaldo?</a>
                      </div>
                      <div class="col-sm">
                          10
                      </div>
                      <div class="col-sm">
                          Admin
                      </div>
                      <div class="col-sm">
                          01-01-2023
                      </div>
                  </div>
                  <div class="row">
                      <div class="col-sm">
                          <a href="/polls?id=2">Mercedes sau BMW?</a>
                      </div>
                      <div class="col-sm">
                          10
                      </div>
                      <div class="col-sm">
                          Admin
                      </div>
                      <div class="col-sm">
                          01-01-2023
                      </div>
                  </div>
              </div>
          </>
      );
  }


}
