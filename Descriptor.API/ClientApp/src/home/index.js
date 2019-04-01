import React, { Component } from 'react';
import { connect } from 'react-redux';
import { loadAllSellers } from '../actions/sellersActions';
import { Table, Container, Row, Col } from 'reactstrap';
import { Link, Switch, Route } from 'react-router-dom';
import SellerInfoModal from '../items/SellerInfoModal';

const initGoogleSearch = () => {
  var cx = '004358329873995088609:hd3fadxvfdc';
  var gcse = document.createElement('script');
  gcse.type = 'text/javascript';
  gcse.async = true;
  gcse.src = 'https://cse.google.com/cse.js?cx=' + cx;
  var s = document.getElementsByTagName('script')[0];
  s.parentNode.insertBefore(gcse, s);
};

const googleCode = `<gcse:searchresults-only noResultsString="No Results" gname="e"></gcse:searchresults-only>`;

const executeSearch = () => {
  const element = window.google.search.cse.element.getElement('e');
  if (element) {
    element.execute(process.env.REACT_APP_SEARCH_QUERY);
    return true;
  } else {
    return false;
  }
}

window.__gcse = {
  parsetags: 'onload',
  callback: () => {
    if (!executeSearch()) {
      window.google.setOnLoadCallback(executeSearch);
    }
  }
};

class Home extends Component {

  componentDidMount() {
    this.props.loadAllSellers();
    initGoogleSearch();
  }

  render() {
    const { sellers, reviewerName } = this.props;
    return (
      <Container>
        <Row>
          <Col>
            <span>Hello {reviewerName}!</span>
          </Col>
        </Row>
        <Row>
          <Col sm={5}>
            <Table>
              <thead>
                <tr>
                  <th>Seller</th>
                  <th>Escalated</th>
                </tr>
              </thead>
              <tbody>
                {
                  sellers.map(x => <tr key={x.ebaySellerUserName}>
                    <td><Link to={`/sellers/${x.ebaySellerUserName}`}>{x.ebaySellerUserName}</Link></td>
                    <td><Link to={`/dashboard/${x.ebaySellerUserName}`}>{x.escalated}</Link></td>
                  </tr>)
                }
              </tbody>
            </Table>
          </Col>
          <Col sm={2}><Link to='/load-items'>Load Items</Link></Col>
          <Col sm={5}>
            <div style={{ maxHeight: '90vh', overflow: 'auto' }} dangerouslySetInnerHTML={{ __html: googleCode }} />
          </Col>
        </Row>
        <Switch>
          <Route path='/sellers/:userName' component={SellerInfoModal} />
        </Switch>
      </Container>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    sellers: state.sellers.list,
    reviewerName: state.oidc.user.profile.given_name
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    loadAllSellers: () => dispatch(loadAllSellers())
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Home);
