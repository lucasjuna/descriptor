import React, { Component } from 'react';
import { Container, Row, Col, Button, Input } from 'reactstrap';
import SellerInfo from './SellerInfo';
import './style.css';
import { loadSeller } from '../actions/sellersActions';
import { connect } from 'react-redux';

class LoadItems extends Component {

  state = {}

  onChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value
    });
  }

  loadSeller = () => {
    if (this.state.userName)
      this.props.loadSeller(this.state.userName);
  }

  render() {
    return (
      <div className='infobox'>
        <Container>
          <Row><h2>Load Items</h2></Row>
          <Row>
            <Col sm={2}><div className='label'>Seller:</div></Col>
            <Col sm={2}><Input onChange={this.onChange} bsSize="sm" name='userName' /></Col>
            <Col><Button onClick={this.loadSeller} size="sm">Load</Button></Col>
          </Row>
        </Container>
        <SellerInfo />
      </div>
    );
  }
}

const mapStateToProps = () => {
  return {};
}

const mapDispatchToProps = (dispatch) => {
  return {
    loadSeller: (userName) => dispatch(loadSeller(userName))
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(LoadItems);