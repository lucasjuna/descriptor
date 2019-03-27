import React, { Component } from 'react';
import { Container, Row, Col, Modal, ModalBody } from 'reactstrap';
import { connect } from 'react-redux';
import SellerInfo from './SellerInfo';
import ReviewsTable from './ReviewsTable';
import './style.css';

class NewSellerInfo extends Component {
  render() {
    const { seller } = this.props;
    return (<Modal isOpen={true}>
      <ModalBody>
        <div className='infobox'>
          <Container>
            <Row>
              <Col sm={2}><div className='label'>Seller:</div></Col>
              <Col sm={2}>
                <strong>{seller && seller.ebaySellerUserName || '-'}</strong>
              </Col>
            </Row>
          </Container>
          <SellerInfo />
          <ReviewsTable />
        </div>
      </ModalBody>
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