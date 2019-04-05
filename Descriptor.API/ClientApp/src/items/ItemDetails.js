import React, { Component } from 'react';
import { Container, Row, Col, Button, Input } from 'reactstrap';
import { loadItem } from '../actions/itemsActions';
import { connect } from 'react-redux';
import { withRouter } from 'react-router';

class ItemDetails extends Component {

  state = {}

  componentDidMount() {
    if (this.props.match.params.itemId) {
      this.props.loadItem(this.props.match.params.itemId);
    }
  }

  render() {
    return (<div>item details...</div>)
  }
}

const mapStateToProps = (state) => {
  return {
    item: state.items.loadedItem
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    loadItem: (itemId) => dispatch(loadItem(itemId)),
  };
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(ItemDetails));