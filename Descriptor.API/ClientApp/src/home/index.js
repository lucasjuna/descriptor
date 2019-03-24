import React, { Component } from 'react';
import { connect } from 'react-redux';
import { loadSellers } from '../actions/sellersActions';

class Home extends Component {
  componentDidMount() {
    this.props.loadSellers();
  }

  render() {
    return (
      <div>Home</div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    sellers: state.sellers,
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    loadSellers: () => dispatch(loadSellers())
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Home);
