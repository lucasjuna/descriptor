import React, { Component } from 'react';
import { connect } from 'react-redux';
import { loadAllSellers } from '../actions/sellersActions';
import { Table, Container, Row, Col } from 'reactstrap';
import { Link } from 'react-router-dom';

(function () {
  var cx = '004358329873995088609:hd3fadxvfdc';
  var gcse = document.createElement('script');
  gcse.type = 'text/javascript';
  gcse.async = true;
  gcse.src = 'https://cse.google.com/cse.js?cx=' + cx;
  var s = document.getElementsByTagName('script')[0];
  s.parentNode.insertBefore(gcse, s);
})()

const googleCode = `<gcse:searchresults-only noResultsString="No Results" gname="e"></gcse:searchresults-only>`;

const initSearch = () => {
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
    if (!initSearch()) {
      window.google.setOnLoadCallback(initSearch);
    }
  }
};

class Home extends Component {

  componentDidMount() {
    this.props.loadAllSellers();
  }

  render() {
    const { sellers } = this.props;
    return (
      <Container>
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
                    <td>{x.ebaySellerUserName}</td>
                    <td>{x.escalated}</td>
                  </tr>)
                }
              </tbody>
            </Table>
          </Col>
          <Col sm={2}><Link to='load-items'>Load Items</Link></Col>
          <Col sm={5}>
            <div style={{ maxHeight: '90vh', overflow: 'auto' }} dangerouslySetInnerHTML={{ __html: googleCode }} />
          </Col>
        </Row>
      </Container>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    sellers: state.sellers.list,
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    loadAllSellers: () => dispatch(loadAllSellers())
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Home);
