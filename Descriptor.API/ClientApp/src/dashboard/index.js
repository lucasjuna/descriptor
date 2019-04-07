import React, { Component } from 'react';
import 'react-tabulator/lib/styles.css'; // required styles
import 'react-tabulator/lib/css/tabulator.min.css'; // theme
import { ReactTabulator, reactFormatter } from 'react-tabulator';
import { connect } from 'react-redux';
import { loadDashboard } from '../actions/dashboardActions';
import { Container, Row, Col } from 'reactstrap';
import { fetchReviewersCb } from '../api/dashboardApi';
import { fetchAllSellers } from '../api/sellersApi';
import './styles.css';
import { withRouter } from 'react-router';
import moment from 'moment';
import { Switch, Route } from 'react-router-dom';
import SellerInfoModal from '../items/SellerInfoModal';
import history from '../history';
import * as FaIcons from 'react-icons/fa';
import { fetchAllReviewers } from '../api/reviewersApi';

const statusEnum = {
  escalated: 1,
  approved: 2,
  rejected: 3
}

const UrlSeller = (props) => {
  let url = `/dashboard/${props.cell._cell.value}/info`;
  return <a href={url} onClick={(e) => {
    e.preventDefault();
    history.push(url, { returnUrl: history.location.pathname });
  }}>{props.cell._cell.value}</a>
}
const UrlItem = (props) => {
  let url = `/dashboard/${props.cell._cell.row.data.seller}/items/${props.cell._cell.value}`;
  return <a href={url} onClick={(e) => {
    e.preventDefault();
    history.push(url, { returnUrl: history.location.pathname });
  }}>{props.cell._cell.value}</a>
}
const UrlDescription = (props) => <a>{props.cell._cell.value}</a>
const StatusCell = (props) => {
  if (!props.cell._cell.value || props.cell._cell.value == statusEnum.escalated)
    return <FaIcons.FaQuestion className='ico ico-escalated' />
  else if (props.cell._cell.value == statusEnum.approved)
    return <FaIcons.FaCheck className='ico ico-approved' />
  else if (props.cell._cell.value == statusEnum.rejected)
    return <FaIcons.FaTimes className='ico ico-rejected' />
  else
    return null;
}

const tableColumns = [
  { title: "Seller", field: "seller", align: "center", formatter: reactFormatter(<UrlSeller />) },
  { title: "Item Number", field: "itemId", align: "center", formatter: reactFormatter(<UrlItem />) },
  { title: "Description", field: "description", align: "center" },
  {
    title: "Review Date/Time", field: "reviewDate", sorter: "date", align: "center", formatter: 'datetime', formatterParams: {
      outputFormat: "MMMM D, YYYY",
      invalidPlaceholder: "",
    }
  },
  { title: "Description ID", field: "descriptionId", align: "center", formatter: reactFormatter(<UrlDescription />) },
  { title: "Short Description", field: "shortDescription", align: "center" },
  { title: "Status", field: "itemStatus", align: "center", formatter: reactFormatter(<StatusCell />) },
  { title: "Reviewer", field: "reviewer", align: "center" },
]

class Dashboard extends Component {

  state = {
    sellers: [],
    reviewers: [],
    dateFrom: moment(new Date()).format('YYYY-MM-DD'),
    dateTo: moment(new Date()).format('YYYY-MM-DD'),
    filterBy: null,
    approver: null
  }

  componentDidMount() {
    this.loadSeller();
    fetchReviewersCb().then(json =>
      this.setState({
        reviewers: json
      }));
    fetchAllSellers().then(json =>
      this.setState({
        sellers: json
      }));
    fetchAllReviewers().then(json =>
      this.setState({
        reviewers: json
      }));
    this.tabulator.table.setFilter(this.filterData);
  }

  componentDidUpdate(prevProps) {
    if (this.props.match.params.userName !== prevProps.match.params.userName)
      this.loadSeller();
  }

  onFilterChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value
    });
  }

  onSellerChange = (e) => {
    this.props.history.push(`/dashboard/${e.target.value}`);
  }

  loadSeller = () => {
    let seller = this.props.match.params.userName;
    this.props.loadDashboard(seller);
    this.setState({
      seller: seller
    })
  }

  filterData = (data, filterParams) => {
    const { filterBy, dateFrom, dateTo, approver } = this.state;
    return (!filterBy || data.itemStatus == filterBy) &&
      (data.itemStatus != statusEnum.approved || !approver || approver == data.reviewerId) &&
        (!data.reviewDate ||
        moment(dateFrom) <= moment(data.reviewDate) &&
        (moment(dateTo).endOf('day') >= moment(data.reviewDate)));
  }

  render() {
    const { reviews } = this.props;
    const { reviewers, sellers, dateFrom, dateTo, filterBy, seller, approver } = this.state;
    return (
      <Container >
        <Row>
          <Col>
            <h3 className='page-header'>Review Dashboard</h3>
          </Col>
        </Row>
        <Row>
          <Col sm={2}><strong className='float-right'>Filter by:</strong></Col>
          <Col sm={2} className='filter-status-choice'>
            <Row>
              <Col sm={7}>
                <input onChange={this.onFilterChange} name='filterBy' type='radio' value={statusEnum.escalated} checked={filterBy == statusEnum.escalated} />
                Escalated
              </Col>
              <Col sm={5}>
                <FaIcons.FaQuestion className='ico ico-escalated' />
              </Col>
            </Row>
            <Row>
              <Col sm={7}>
                <input onChange={this.onFilterChange} name='filterBy' type='radio' value={statusEnum.rejected} checked={filterBy == statusEnum.rejected} />
                Rejected
              </Col>
              <Col sm={5}>
                <FaIcons.FaTimes className='ico ico-rejected' />
              </Col>
            </Row>
            <Row>
              <Col sm={7}>
                <input onChange={this.onFilterChange} name='filterBy' type='radio' value={statusEnum.approved} checked={filterBy == statusEnum.approved} />
                Approved
              </Col>
              <Col sm={5}>
                <FaIcons.FaCheck className='ico ico-approved' />
              </Col>
            </Row>
            <Row>
              <Col sm={9}>
                <input onChange={this.onFilterChange} name='filterBy' type='radio' value={null} checked={!filterBy} />
                All
              </Col>
            </Row>
          </Col>
          <Col sm={4}>
            <Row>
              <Col><strong className='float-right'>Seller:</strong></Col>
              <Col>
                <select className='w-100' name='seller' value={seller} onChange={this.onSellerChange}>
                  {sellers.map(x => <option key={x.ebaySellerUserName} value={x.ebaySellerUserName}>{x.ebaySellerUserName}</option>)}
                </select></Col>
            </Row>
            <Row>
              <Col><strong className='float-right'>Approver:</strong></Col>
              <Col>
                <select className='w-100' name='approver' value={approver} onChange={this.onFilterChange}>
                  <option value={null}>All</option>
                  {reviewers.map(x => <option key={x.id} value={x.id}>{x.firstName} {x.lastName}</option>)}
                </select>
              </Col>
            </Row>
          </Col>
          <Col sm={4}>
            <Row>
              <Col><strong className='float-right'>From:</strong></Col>
              <Col><input name='dateFrom' onChange={this.onFilterChange} type='date' value={dateFrom} /></Col>
            </Row> <Row>
              <Col><strong className='float-right'>To:</strong></Col>
              <Col><input name='dateTo' onChange={this.onFilterChange} type='date' value={dateTo} /></Col>
            </Row></Col>
        </Row>
        <Row>
          <Col>
            <ReactTabulator ref={(r) => this.tabulator = r} columns={tableColumns} data={reviews} />
          </Col>
        </Row>
        <Switch>
          <Route path='/dashboard/:userName/info' component={SellerInfoModal} />
        </Switch>
      </Container>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    reviews: state.dashboard.items
  }
}
const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    loadDashboard: (userName) => dispatch(loadDashboard(userName))
  }
}
export default withRouter(connect(mapStateToProps, mapDispatchToProps)(Dashboard));