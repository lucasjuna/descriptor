import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { connect } from 'react-redux';
import './style.css';

class ReviewsTable extends Component {
  render() {
    const { reviewsResult, itemsLoading } = this.props;
    const total = reviewsResult.accepted + reviewsResult.rejected + reviewsResult.escalated;
    return (<div>
      <Table className='reviews-result'>
        <thead>
          <tr>
            <th>Accepted</th>
            <th>Rejected</th>
            <th>Escalated</th>
            <th>Total</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>{reviewsResult && reviewsResult.accepted >= 0 ? reviewsResult.accepted : '-'}</td>
            <td>{reviewsResult && reviewsResult.rejected >= 0 ? reviewsResult.rejected : '-'}</td>
            <td>{reviewsResult && reviewsResult.escalated >= 0 ? reviewsResult.escalated : '-'}</td>
            <td>{reviewsResult && total >= 0 ? total : '-'}</td>
          </tr>
          <tr>
            <td>{reviewsResult && total ? `${reviewsResult.accepted * 100 / total}%` : '-'}</td>
            <td>{reviewsResult && total ? `${reviewsResult.rejected * 100 / total}%` : '-'}</td>
            <td>{reviewsResult && total ? `${reviewsResult.escalated * 100 / total}%` : '-'}</td>
            <td></td>
          </tr>
        </tbody>
      </Table>
      {
        itemsLoading ?
          <span>Loading...</span>
          :
          null
      }
    </div>)
  }
}

const mapStateToProps = (state) => {
  return {
    reviewsResult: state.items.reviewsResult,
    itemsLoading: state.items.itemsLoading,
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    dispatch
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ReviewsTable);