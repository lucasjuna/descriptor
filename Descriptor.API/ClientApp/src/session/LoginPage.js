import React from "react";
import userManager from "./userManager";
import { connect } from 'react-redux';

class LoginPage extends React.Component {

  componentWillMount() {
    if (this.props.isLoadingUser)
      userManager.signinRedirect();
  }

  render() {
    return (
      <div>Redirecting...</div>
    );
  }
}

function mapStateToProps(state) {
  return {
    isLoadingUser: state.oidc.isLoadingUser
  };
}

function mapDispatchToProps(dispatch) {
  return {
    dispatch
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(LoginPage);
