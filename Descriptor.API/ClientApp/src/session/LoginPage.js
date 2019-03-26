import React from "react";
import userManager from "./userManager";
import { connect } from 'react-redux';

class LoginPage extends React.Component {

  componentDidMount() {
    const wait = () => new Promise(resolve => setTimeout(resolve, 5000));
    wait().then(() => {
      if (!this.props.isLoadingUser) {
        this.redirect();
      }
    })
  }

  componentDidUpdate(prevProps) {
    if (!this.props.isLoadingUser && prevProps.isLoadingUser !== this.props.isLoadingUser) {
      this.redirect();
    }
  }

  redirect = () => {
    userManager.signinRedirect().catch(error => {
      console.error(error);
      setTimeout(() => {
        this.redirect();
      }, 1000);
    });
  }

  render() {
    return (
      <div>Redirecting...</div>
    );
  }
}

function mapStateToProps(state) {
  return {
    isLoadingUser: state.oidc.isLoadingUser,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    dispatch
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(LoginPage);
