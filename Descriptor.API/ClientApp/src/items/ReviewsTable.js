import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { connect } from 'react-redux';
import './style.css';

class ReviewsTable extends Component {
  render() {
    const { reviewResults } = this.props;
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
          <td>{reviewResults && reviewResults.accepted || '-'}</td>
          <td>{reviewResults && reviewResults.rejected|| '-'}</td>
          <td>{reviewResults && reviewResults.escalated|| '-'}</td>
          <td>{reviewResults && reviewResults.total|| '-'}</td>
        </tr>
        <tr>
          <td>{reviewResults && reviewResults.accepted * 100 / reviewResults.total|| '-'}%</td>
          <td>{reviewResults && reviewResults.rejected * 100 / reviewResults.total|| '-'}%</td>
          <td>{reviewResults && reviewResults.escalated * 100 / reviewResults.total|| '-'}%</td>
          <td></td>
        </tr>
      </tbody>
    </Table>)
  }
}

const mapStateToProps = (state) => {
  return {
    reviewResults: state.items.reviewResults,
  };
}

const mapDispatchToProps = (dispatch) => {
  return {
    dispatch
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ReviewsTable);