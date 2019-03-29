import React, { Component } from 'react';
import { Container, Row, Col, Modal, ModalBody, ModalFooter, Button } from 'reactstrap';
import { connect } from 'react-redux';
import SellerInfo from './SellerInfo';
import ReviewsTable from './ReviewsTable';
import './style.css';
import { Link } from 'react-router-dom';

class NewSellerInfo extends Component {
  render() {
    const { seller } = this.props;
    return (<Modal isOpen={true} className='reviews-result-dialog'>
      <ModalBody>
        <div className='infobox'>
          <Container>
            <Row>
              <Col sm={3}><div className='label'>Seller:</div></Col>
              <Col sm={9}>
                <strong>{seller && seller.ebaySellerUserName || '-'}</strong>
              </Col>
            </Row>
            <Row>
              <Col>
                <SellerInfo className='seller-info'/>
              </Col>
            </Row>
            <Row>
              <Col sm={3}><div className='label'>Reviews history:</div></Col>
              <Col>
                <ReviewsTable />
              </Col>
            </Row>
          </Container>
        </div>
      </ModalBody>
      <ModalFooter>
        <Button tag={Link} to='/'>Close</Button>
      </ModalFooter>
    </Modal>)
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

export default connect(mapStateToProps, mapDispatchToProps)(NewSellerInfo);