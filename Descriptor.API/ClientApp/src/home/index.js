import React, { Component } from 'react';
import userManager from '../session/userManager';

class Home extends Component {

  logout = () => {
    userManager.signoutRedirect();
  }

  render() {
    return (
      <div>
        <div>Home</div>
      </div>
    );
  }
}

export default Home;
