import React from 'react'
import { Switch, Route } from 'react-router-dom';
import Home from './home';
import Header from './Header';
import LoadItems from './items/LoadItems';

const Main = () => (
  <main>
    <Header />
    <Switch>
      <Route exact path='/' component={Home} />
      <Route exact path='/load-items' component={LoadItems} />
    </Switch>
  </main>
)

export default Main