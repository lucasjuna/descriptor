import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';
import { connect } from 'react-redux';
import './styles.css';

class SellerInfo extends Component {

  render() {
    const { seller } = this.props;

    if (!seller)
      return null;

    return (
      <Container className='seller-info'>
        <Row>
          <Col sm={3}><div className='label'>First Name:</div></Col>
          <Col sm={3}><div className='textbox'>{seller.firstName || 'N/A'}</div></Col>
          <Col sm={3}><div className='label'>Last Name:</div></Col>
          <Col sm={3}><div className='textbox'>{seller.lastName || 'N/A'}</div></Col>
        </Row>
        <Row>
          <Col sm={3}><div className='label'>eMail:</div></Col>
          <Col><div className='textbox'>{seller.emailAddress || 'N/A'}</div></Col>
        </Row>
        <Row>
          <Col sm={3}><div className='label'>Address:</div></Col>
          <Col><div className='textbox address'>{seller.address || 'N/A'}</div></Col>
        </Row>
      </Container>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    seller: state.sellers.loadedSeller,
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    dispatch
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(SellerInfo);