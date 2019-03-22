import React from 'react'
import { Switch, Route } from 'react-router-dom';
import Home from './home';
import Header from './Header'

const Main = () => (
  <main>
    <Header />
    <Switch>
      <Route exact path='/' component={Home} />
    </Switch>
  </main>
)

export default Main