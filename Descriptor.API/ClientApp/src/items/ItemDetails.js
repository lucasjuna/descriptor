import React, { Component } from 'react';
import { Container, Row, Col, Button, Input } from 'reactstrap';
import { loadItem } from '../actions/itemsActions';
import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { Link } from 'react-router-dom';
import StatusInput from './StatusInput';
import StatusEnum from './StatusEnum';
import { ReactTabulator, reactFormatter } from 'react-tabulator';
import { fetchSubmitReview } from '../api/itemsApi';

const ImageCell = (props) => {
  return <img className='product-image' src={props.cell._cell.value} alt={props.cell._cell.value} />
}

const RadioCell = (props) => {
  return <input type='radio' name='descriptionId' value={props.cell._cell.value}
    checked={props.cell._cell.row.data.active} onChange={props.cell._cell.row.data.onChange} />
}

const imagesTableColumns = [
  { field: "imageUrl", align: "center", formatter: reactFormatter(<ImageCell />) },
]

const decriptionsTableColumn = [
  { title: "Description ID", field: "id", align: "center", width: 100 },
  { title: "Description", field: "shortDescription", align: "center" },
  { title: "C %", field: "percent", align: "center", width: 50 },
  { field: "id", align: "center", width: 50, formatter: reactFormatter(<RadioCell />) },
]

class ItemDetails extends Component {

  state = {
    canApprove: false,
    descriptions: []
  }

  componentDidMount() {
    if (this.props.match.params.itemId) {
      this.props.loadItem(this.props.match.params.itemId);
    }
  }

  componentDidUpdate(prevProps) {
    if (this.props.item !== prevProps.item)
      this.setState(this.props.item, () => {
        let description = this.state.descriptions.find(x => x.id == this.props.item.descriptionId)
        this.setDescription(description);
        this.checkCanApprove();
      });
  }

  onStatusChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value
    }, this.checkCanApprove);
  }

  onDescriptionStatusChange = (e) => {
    let description = this.state.descriptions.find(x => x.id == this.state.descriptionId);
    if (description) {
      description.status = e.target.value;
      this.setState({
        descriptionStatus: description.status
      }, this.checkCanApprove);
    }
  }

  onDescriptionChange = (e) => {
    let description = this.state.descriptions.find(x => x.id == e.target.value)
    this.setDescription(description);
  }

  setDescription = (description) => {
    if (description) {
      this.setState({
        descriptionId: description.id,
        shortDescription: description.shortDescription,
        descriptionStatus: description.status
      }, this.checkCanApprove);
    }
  }

  checkCanApprove = () => {
    let canApprove = false;
    this.setState((prevState, props) => ({
      canApprove: canApprove = prevState.imagesStatus == StatusEnum.approved &&
        prevState.descriptionStatus == StatusEnum.approved &&
        prevState.priceStatus == StatusEnum.approved,
      itemStatus: !canApprove && prevState.itemStatus == StatusEnum.approved ? StatusEnum.unknown : prevState.itemStatus
    }));
  }

  save = () => {
    const { itemId, descriptionId, itemStatus, imagesStatus, priceStatus, descriptions } = this.state;
    let review = {
      itemId,
      descriptionId,
      itemStatus,
      imagesStatus,
      priceStatus,
      descriptions
    }
    fetchSubmitReview(this.props.match.params.itemId, review).then(x => this.props.history.goBack())
  }

  render() {
    const { item, location: { pathname }, history } = this.props;
    const { itemStatus, imagesStatus, descriptionStatus, priceStatus, canApprove, descriptions, descriptionId, shortDescription } = this.state;
    const imageUrls = item && item.imageUrls && item.imageUrls.split('\n').map(x => {
      return {
        imageUrl: x
      }
    }) || [];
    const descriptionsList = descriptions.map(x => {
      x.onChange = this.onDescriptionChange;
      x.active = x.id == descriptionId;
      return x;
    });
    return (
      <Container className='h-100'>
        <div className='item-details vertical-container'>
          <div className='horizontal-container'>
            <div className='header w-100'>
              <Container >
                <Row>
                  <Col className='pl-0'>
                    <Button onClick={this.save}>Save</Button>
                    <span className='status-label mr-2'>
                      Status:
                </span>
                    <StatusInput canApprove={canApprove} name='itemStatus' value={itemStatus} onChange={this.onStatusChange} showLabel />
                  </Col>
                  <Col className="text-center">
                    <h4>
                      Details for Item: <Link to={pathname}>{this.props.match.params.itemId}</Link>
                    </h4>
                  </Col>
                  <Col className='pr-0'>
                    <Button className='float-right' onClick={history.goBack}>Cancel</Button>
                  </Col>
                </Row>
              </Container>
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
                      <Col>
                        <div className='long-description'>{item.longDescription}</div>
                      </Col>
                    </Row>
                  </Col>
                  <Col>
                    <Row>
                      <Col>
                        {descriptionId ? `${descriptionId} - ${shortDescription}` : null}
                        <StatusInput name='descriptionStatus' className='float-right' value={descriptionStatus} onChange={this.onDescriptionStatusChange} />
                      </Col>
                    </Row>
                    <Row className='h-80'>
                      <Col>
                        <ReactTabulator ref={r => this.tableDescriptions = r}
                          columns={decriptionsTableColumn}
                          data={descriptionsList || []}
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
                    Item pictures: <StatusInput name='imagesStatus' className='float-right' value={imagesStatus} onChange={this.onStatusChange} />
                  </Col>
                </Row>
                <Row>
                  <Col>
                    <ReactTabulator className='no-header images-table'
                      columns={imagesTableColumns}
                      data={imageUrls}
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
                      <StatusInput name='priceStatus' value={priceStatus} onChange={this.onStatusChange} />
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
                  <Col sm={9}><a className='item-url' href={item.itemUrl}>{item.itemUrl}</a></Col>
                </Row>
              </Container>
            </div>
          </div>
        </div>
      </Container>
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