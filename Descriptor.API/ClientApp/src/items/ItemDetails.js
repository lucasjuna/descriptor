import React, { Component } from 'react';
import { Container, Row, Col, Button, Input } from 'reactstrap';
import { loadItem } from '../actions/itemsActions';
import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { Link } from 'react-router-dom';
import StatusInput from './StatusInput';
import { ReactTabulator, reactFormatter } from 'react-tabulator';

const imagesTableColumns = [
  { field: "image", align: "center" },
]

const decriptionsTableColumn = [
  { title: "Description ID", field: "id", align: "center", width: 100 },
  { title: "Description", field: "shortDescription", align: "center" },
  { title: "C %", field: "percent", align: "center", width: 50 },
  { field: "active", align: "center", width: 50 },
]

class ItemDetails extends Component {

  state = {}

  componentDidMount() {
    if (this.props.match.params.itemId) {
      this.props.loadItem(this.props.match.params.itemId);
    }
  }

  render() {
    const { item, location: { pathname }, history } = this.props;
    return (
      <div className='h-100'>
        <div className='item-details vertical-container'>
          <div className='horizontal-container'>
            <div className='header w-100'>
              <div>
                <Button>Save</Button>
                <span className='status-label mr-2'>
                  Status:
                </span>
                <StatusInput value={item.itemStatus} showLabel />
              </div>
              <div>
                <h4>
                  Details for Item: <Link to={pathname}>{this.props.match.params.itemId}</Link>
                </h4>
              </div>
              <div>
                <Button onClick={history.goBack}>Cancel</Button>
              </div>
            </div>
          </div>
          <div className='horizontal-container grow'>
            <div className='segment lg' ref={r => this.ltSegment = r}>
              <Container className='h-100'>
                <Row className='h-100'>
                  <Col>
                    <Row>
                      <Col>Description ID and Short Description:</Col>
                    </Row>
                    <Row>
                      <Col>
                        <strong>Item description:</strong>
                      </Col>
                    </Row>
                    <Row>
                      <Col>{item.description}</Col>
                    </Row>
                    <Row>
                      <Col>
                        <strong>Description:</strong>
                      </Col>
                    </Row>
                    <Row>
                      <Col>{item.description}</Col>
                    </Row>
                  </Col>
                  <Col>
                    <Row>
                      <Col>
                        {item.descriptionId ? `${item.descriptionId} - ${item.shortDescription}` : null}
                        <StatusInput className='float-right' value={item.itemStatus} />
                      </Col>
                    </Row>
                    <Row className='h-80'>
                      <Col>
                        <ReactTabulator ref={r => this.tableDescriptions = r} 
                          columns={decriptionsTableColumn} 
                          data={item.descriptions || []} 
                          options={{ height: '54vh' }} />
                      </Col>
                    </Row>
                  </Col>
                </Row>
              </Container>
            </div>
            <div className='segment sm'>
              <Container>
                <Row>
                  <Col>
                    Item pictures: <StatusInput className='float-right' value={item.itemStatus} />
                  </Col>
                </Row>
                <Row>
                  <Col>
                    <ReactTabulator className='no-header' 
                    columns={imagesTableColumns} 
                    data={[]}
                    options={{ height: '55vh' }} />
                  </Col>
                </Row>
              </Container>
            </div>
          </div>
          <div className='horizontal-container'>
            <div className='segment lg'>
              <Container>
                <Row>
                  <Col>
                    <strong>Import Duty and Taxes</strong>
                    <span className='float-right'>
                      <span className='mr-3'>Duty free:</span>
                      <StatusInput value={item.itemStatus} />
                    </span>
                  </Col>
                </Row>
                <Row>
                  <Col sm={7}>Price: ${item.price}</Col>
                  <Col sm={5}>Duties: </Col>
                </Row>
                <Row>
                  <Col sm={7}>Lot Size: 0</Col>
                  <Col sm={5}>Taxes: </Col>
                </Row>
              </Container>
            </div>
            <div className='segment sm'>
              <Container>
                <Row>
                  <Col sm={3}>Item URL: </Col>
                  <Col sm={9}><a href={item.itemUrl}>{item.itemUrl}</a></Col>
                </Row>
              </Container>
            </div>
          </div>
        </div>
      </div>
    )
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