import React from 'react'
import { Switch, Route } from 'react-router-dom';
import Home from './home';
import Header from './Header';
import LoadItems from './items/LoadItems';
import Dashboard from './dashboard';

const Main = () => (
  <main>
    <Header />
    <Switch>
      <Route path='/load-items' component={LoadItems} />
      <Route path='/dashboard/:userName' component={Dashboard} />
      <Route path='/' component={Home} />
    </Switch>
  </main>
)

export default Main