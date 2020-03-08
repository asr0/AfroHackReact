import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import About from './components/About';
import Login from './components/Login';
import Welcome from './components/Welcome';

import './custom.css'

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {

    };
  }

  render () {
    return (
      <Welcome />
      // <Layout>
      //   <Route exact path='/' component={Home} />
      //   <Route path='/login' component={Login} />
      //   <Route path='/about' component={About} />
      // </Layout>
    );
  }
}
