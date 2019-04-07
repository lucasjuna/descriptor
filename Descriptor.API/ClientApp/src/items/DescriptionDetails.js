import React, { Component } from 'react';
import { Container, Row, Col, Modal, ModalBody, ModalFooter, Button } from 'reactstrap';
import { connect } from 'react-redux';
import SellerInfo from './SellerInfo';
import ReviewsTable from './ReviewsTable';
import './style.css';
import { Link } from 'react-router-dom';
import { loadDescription } from '../actions/itemsActions';

class DescriptionDetails extends Component {

  componentDidMount() {
    this.props.loadDescription(this.props.match.params.itemId, this.props.match.params.descriptionId);
  }

  render() {
    const { description, history } = this.props;
    return (<Modal isOpen={true}>
      <ModalBody>
        <div className='infobox'>
          <Container>
            <Row>
              <Col sm={4}><div className='label'>Description ID:</div></Col>
              <Col sm={8}>
                {description.id} {description.shortDescription}
              </Col>
            </Row>
            <Row>
              <Col sm={4}><div className='label'>Description:</div></Col>
              <Col sm={8}>
                <div className='textbox long-description'>{description.longDescription || '-'}</div>
              </Col>
            </Row>
            <Row>
              <Col sm={4}><div className='label'>Note:</div></Col>
              <Col sm={8}>
                <div className='textbox'>{description.note || '-'}</div>
              </Col>
            </Row>
            <Row>
              <Col sm={4}><div className='label'>Begin Effective:</div></Col>
              <Col sm={2}>
                <div className='textbox'>{description.beginEffective || '-'}</div>
              </Col>
              <Col sm={4}><div className='label'>End Effective:</div></Col>
              <Col sm={2}>
                <div className='textbox'>{description.endEffective || '-'}</div>
              </Col>
            </Row>
          </Container>
        </div>
      </ModalBody>
      <ModalFooter>
        <Button onClick={history.goBack}>Close</Button>
      </ModalFooter>
    </Modal>)
  }
}

const mapStateToProps = (state) => {
  return {
    description: state.items.loadedDescription,
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    loadDescription: (itemId, descriptionId) => dispatch(loadDescription(itemId, descriptionId)),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(DescriptionDetails);