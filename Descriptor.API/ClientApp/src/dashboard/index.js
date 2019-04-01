import React, { Component } from 'react';
import 'react-tabulator/lib/styles.css'; // required styles
import 'react-tabulator/lib/css/tabulator.min.css'; // theme
import { ReactTabulator } from 'react-tabulator'; // for React 15.x, use import { React15Tabulator }
import { connect } from 'react-redux';
import { loadDashboard } from '../actions/dashboardActions';
import { Container, Row, Col } from 'reactstrap';
import { fetchReviewersCb } from '../api/dashboardApi';
import './styles.css';

const tableColumns = [
  { title: "Seller", field: "seller", align: "center", formatter: "link" },
  { title: "Item Number", field: "itemNumber", align: "center", formatter: "link" },
  { title: "Description", field: "description", align: "center" },
  {
    title: "Review Date/Time", field: "reviewDate", sorter: "date", align: "center", formatter: 'datetime', formatterParams: {
      outputFormat: "MMMM D, YYYY",
      invalidPlaceholder: "(invalid date)",
    }
  },
  { title: "Description ID", field: "descriptionId", align: "center", formatter: "link" },
  { title: "Short Description", field: "shortDescription", align: "center" },
  { title: "Status", field: "status", align: "center" },
  { title: "Reviewer", field: "reviewer", align: "center" },
]

class Dashboard extends Component {

  state = {
    sellers: [{
      id: 1,
      name: 'shoppingLeader'
    }],
    reviewers: [],
    dateFrom: new Date,
    dateTo: new Date,
    filterBy: "escalated"
  }

  componentDidMount() {
    this.props.loadDashboard();
    fetchReviewersCb().then(json =>
      this.setState({
        reviewers: json
      }));
  }

  render() {
    const { reviews } = this.props;
    const { reviewers, sellers, dateFrom, dateTo, filterBy } = this.state;
    return (
      <Container >
        <Row>
          <Col>
            <h3 className='page-header'>Review Dashboard</h3>
          </Col>
        </Row>
        <Row>
          <Col sm={2}><strong className='float-right'>Filter by:</strong></Col>
          <Col sm={2}>
            <Row>
              <Col><input type='radio' value='escalated' checked={filterBy === 'escalated'}/>Escalated</Col>
            </Row>
            <Row>
              <Col><input type='radio' value='rejected' checked={filterBy === 'rejected'}/>Rejected</Col>
            </Row>
            <Row>
              <Col><input type='radio' value='accepted' checked={filterBy === 'accepted'}/>Accepted</Col>
            </Row>
            <Row>
              <Col><input type='radio' value='all' checked={filterBy === 'all'}/>All</Col>
            </Row>
          </Col>
          <Col sm={4}>
            <Row>
              <Col><strong className='float-right'>Seller:</strong></Col>
              <Col>
                <select className='w-100'>
                  {sellers.map(x => <option key={x.id} value={x.id}>{x.name}</option>)}
                </select></Col>
            </Row> <Row>
              <Col><strong className='float-right'>Approver:</strong></Col>
              <Col>
                <select className='w-100'>
                  {reviewers.map(x => <option key={x.id} value={x.id}>{x.name}</option>)}
                </select>
              </Col>
            </Row>
          </Col>
          <Col sm={4}>
            <Row>
              <Col><strong className='float-right'>From:</strong></Col>
              <Col><input type='date' /></Col>
            </Row> <Row>
              <Col><strong className='float-right'>To:</strong></Col>
              <Col><input type='date' /></Col>
            </Row></Col>
        </Row>
        <Row>
          <Col>
            <ReactTabulator columns={tableColumns} data={reviews} />
          </Col>
        </Row>
      </Container>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    reviews: state.dashboard.items
  }
}
const mapDispatchToProps = (dispatch) => {
  return {
    loadDashboard: () => dispatch(loadDashboard())
  }
}
export default connect(mapStateToProps, mapDispatchToProps)(Dashboard);