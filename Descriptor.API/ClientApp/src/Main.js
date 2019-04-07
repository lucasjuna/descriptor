import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';
import Home from './home';
import Header from './Header';
import LoadItems from './items/LoadItems';
import Dashboard from './dashboard';
import ItemDetails from './items/ItemDetails';
import { fetchInitReviewer } from './api/reviewersApi';
import { withRouter } from 'react-router';

class Main extends Component {

  componentDidMount() {
    fetchInitReviewer();
  }

  render() {
    return (<main>
      <Header />
      <Switch>
        <Route path='/load-items' component={LoadItems} />
        <Route path='/dashboard/:userName/items/:itemId' component={ItemDetails} />
        <Route path='/dashboard/:userName' component={Dashboard} />
        <Route path='/' component={Home} />
      </Switch>
    </main>)
  }
}

export default withRouter(Main)