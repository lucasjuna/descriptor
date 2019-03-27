import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { connect } from 'react-redux';
import './style.css';

class ReviewsTable extends Component {
  render() {
    const { reviewsResult } = this.props;
    return (<Table>
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
          <td>{reviewsResult && reviewsResult.accepted || '-'}</td>
          <td>{reviewsResult && reviewsResult.rejected || '-'}</td>
          <td>{reviewsResult && reviewsResult.escalated || '-'}</td>
          <td>{reviewsResult && reviewsResult.total || '-'}</td>
        </tr>
        <tr>
          <td>{reviewsResult && reviewsResult.total ? `${reviewsResult.accepted * 100 / reviewsResult.total}` : '-'}</td>
          <td>{reviewsResult && reviewsResult.total ? `${reviewsResult.rejected * 100 / reviewsResult.total}` : '-'}</td>
          <td>{reviewsResult && reviewsResult.total ? `${reviewsResult.escalated * 100 / reviewsResult.total}` : '-'}</td>
          <td></td>
        </tr>
      </tbody>
    </Table>)
  }
}

const mapStateToProps = (state) => {
  return {
    reviewsResult: state.items.reviewsResult,
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    dispatch
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ReviewsTable);