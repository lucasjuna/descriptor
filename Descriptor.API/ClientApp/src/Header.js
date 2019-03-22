import React, { Component } from 'react'
import userManager from './session/userManager';

class Header extends Component {

  logout = () => {
    userManager.signoutRedirect();
  }

  render() {
    return (<div>
      <a href="#" onClick={this.logout}>Logout</a>
    </div>)
  }
}

export default Header
