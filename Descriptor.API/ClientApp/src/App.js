import React, { Component } from 'react';
import { Provider } from 'react-redux';
import { OidcProvider } from 'redux-oidc';
import Entry from './Entry'
import store from './store';
import userManager from './session/userManager';
import { Switch, Route } from 'react-router-dom'
import CallbackPage from './session/CallbackPage'
import './App.css';
import { ToastContainer } from 'react-toastify';

class App extends Component {
  render() {
    return (
      <Provider store={store}>
        <OidcProvider store={store} userManager={userManager}>
          <div>
            <Switch>
              <Route exact path='/callback' component={CallbackPage} />
              <Route path='/' component={Entry} />
            </Switch>
            <ToastContainer />
          </div>
        </OidcProvider>
      </Provider>
    );
  }
}

export default App;
