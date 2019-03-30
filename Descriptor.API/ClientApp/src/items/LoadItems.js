import React, { Component } from 'react';
import { Container, Row, Col, Button, Input } from 'reactstrap';
import SellerInfo from './SellerInfo';
import './style.css';
import { loadSeller, clearSeller } from '../actions/sellersActions';
import { loadItems } from '../actions/itemsActions';
import { connect } from 'react-redux';
import NewSellerInfo from './NewSellerInfo';
import { Route } from 'react-router-dom';
import Switch from 'react-router-dom/Switch';
import { withRouter } from 'react-router';

class LoadItems extends Component {

  state = {}

  componentDidMount() {
    this.props.clearSeller();
  }

  onChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value
    });
  }

  loadSeller = () => {
    if (this.state.userName)
      this.props.loadSeller(this.state.userName);
  }

  loadItems = () => {
    if (this.props.seller && this.props.seller.ebaySellerUserName)
      this.props.loadItems(this.props.seller.ebaySellerUserName);
  }

  render() {
    const { seller, loadItems, itemsLoading } = this.props;

    return (
      <div className='infobox load-items'>
        <Container>
          <Row><h2>Load Items</h2></Row>
          <Row>
            <Col sm={3}><div className='label'>Seller:</div></Col>
            <Col sm={3}><Input onChange={this.onChange} bsSize="sm" name='userName' /></Col>
            <Col><Button onClick={this.loadSeller} size="sm">Load</Button></Col>
          </Row>
        </Container>
        <Switch>
          <Route exact path={`/load-items/new-seller`} component={NewSellerInfo} />
          <Route exact path={`/load-items`} component={(props) => {
            return (<div>
              <SellerInfo />
              {
                seller ?
                  <div>
                    <Row>
                      <Col sm={2}></Col>
                      <Col sm={3}><div className='label'># loaded items:</div></Col>
                      <Col sm={1}><div className='textbox'>{seller.total || 0}</div></Col>
                    </Row>
                    <Row>
                      <Col sm={3}></Col>
                      <Col sm={2}><Button size="sm" onClick={this.loadItems}>Load new items</Button></Col>
                      <Col ><Button size="sm">Review existing items</Button></Col>
                    </Row>
                    <Row>
                      <Col sm={3}></Col>
                      <Col>
                        {
                          itemsLoading ?
                            <span>Loading...</span>
                            :
                            null
                        }
                      </Col>
                    </Row>
                  </div>
                  :
                  null
              }
            </div>)
          }} />
        </Switch>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    seller: state.sellers.loadedSeller,
    itemsLoading: state.items.itemsLoading
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    loadSeller: (userName) => dispatch(loadSeller(userName)),
    loadItems: (userName) => dispatch(loadItems(userName)),
    clearSeller: () => dispatch(clearSeller())
  };
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(LoadItems));