import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import { processSilentRenew } from 'redux-oidc';
import { Router } from 'react-router-dom';
import 'semantic-ui-css/semantic.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'react-confirm-alert/src/react-confirm-alert.css';
import history from './history';
import 'react-toastify/dist/ReactToastify.css';
import moment from 'moment';

if (window.location.pathname === '/silent-renew') {
  processSilentRenew();
} else {
  window.moment = moment;
  ReactDOM.render(
    <Router history={history}>
      <App />
    </Router>,
    document.getElementById('root'));
}

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
