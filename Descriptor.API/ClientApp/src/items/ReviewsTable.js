import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { connect } from 'react-redux';
import './styles.css';

class ReviewsTable extends Component {
  render() {
    const { accepted, rejected, escalated, total, itemsLoading } = this.props;
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
            <td>{accepted >= 0 ? accepted : '-'}</td>
            <td>{rejected >= 0 ? rejected : '-'}</td>
            <td>{escalated >= 0 ? escalated : '-'}</td>
            <td>{total >= 0 ? total : '-'}</td>
          </tr>
          <tr>
            <td>{total ? `${accepted * 100 / total}%` : '-'}</td>
            <td>{total ? `${rejected * 100 / total}%` : '-'}</td>
            <td>{total ? `${escalated * 100 / total}%` : '-'}</td>
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
    accepted: state.sellers.loadedSeller && state.sellers.loadedSeller.accepted,
    rejected: state.sellers.loadedSeller && state.sellers.loadedSeller.rejected,
    escalated: state.sellers.loadedSeller && state.sellers.loadedSeller.escalated,
    total: state.sellers.loadedSeller && state.sellers.loadedSeller.total,
    itemsLoading: state.sellers.itemsLoading,
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    dispatch
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ReviewsTable);