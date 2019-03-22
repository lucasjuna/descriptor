import React, { Component } from 'react';
import { connect } from 'react-redux';
import Main from './Main'
import LoginPage from './session/LoginPage';
import { withRouter } from 'react-router';

class Entry extends Component {

  render() {
    let user = this.props.user;

    if (!user || user.expired) {
      return <LoginPage />
    }
    else {
      return <div>
        <Main />
      </div>
    }
  }
}

function mapStateToProps(state) {
  return {
    user: state.oidc.user
  };
}

function mapDispatchToProps(dispatch) {
  return {
    dispatch
  };
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(Entry));
