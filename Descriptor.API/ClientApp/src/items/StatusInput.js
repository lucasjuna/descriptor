import React, { Component } from 'react';
import { Container, Row, Col, Button } from 'reactstrap';
import * as FaIcons from 'react-icons/fa';
import StatusEnum from './StatusEnum';
import { Popup } from 'semantic-ui-react';
import PropTypes from 'prop-types';

class StatusInput extends Component {
  render() {
    const { value, name, onChange, showLabel, canApprove, className } = this.props;
    let icon;
    let label = 'N/A';
    if (!value) {
      icon = <FaIcons.FaQuestion className='ico ico-escalated' />
    }
    else if (value == StatusEnum.escalated) {
      icon = <FaIcons.FaQuestion className='ico ico-escalated' />
      label = 'Escalated';
    }
    else if (value == StatusEnum.approved) {
      icon = <FaIcons.FaCheck className='ico ico-approved' />
      label = 'Approved';
    }
    else if (value == StatusEnum.rejected) {
      icon = <FaIcons.FaTimes className='ico ico-rejected' />
      label = 'Rejected';
    }

    return (<span className={className}>
      <Popup
        trigger={<Button>{icon}</Button>}
        content={<Container sm={2} className='filter-status-choice'>
          <Row>
            <Col sm={9}>
              <input onChange={onChange} name={name} type='radio' value={StatusEnum.escalated} checked={value == StatusEnum.escalated} />
              Escalated
          </Col>
            <Col sm={3}>
              <FaIcons.FaQuestion className='ico ico-escalated' />
            </Col>
          </Row>
          <Row>
            <Col sm={9}>
              <input onChange={onChange} name={name} type='radio' value={StatusEnum.rejected} checked={value == StatusEnum.rejected} />
              Rejected
          </Col>
            <Col sm={3}>
              <FaIcons.FaTimes className='ico ico-rejected' />
            </Col>
          </Row>
          <Row>
            <Col sm={9}>
              <input disabled={!canApprove} onChange={onChange} name={name} type='radio' value={StatusEnum.approved} checked={value == StatusEnum.approved} />
              Approved
          </Col>
            <Col sm={3}>
              <FaIcons.FaCheck className='ico ico-approved' />
            </Col>
          </Row>
          <Row>
            <Col sm={9}>
              <input onChange={onChange} name={name} type='radio' value={null} checked={!value} />
              N/A
          </Col>
          </Row>
        </Container>}
        on='click'
        hideOnScroll
      />{showLabel ? <span className='ml-2'>{label}</span> : null}
    </span>)
  }
}
StatusInput.propTypes = {
  canApprove: PropTypes.bool
};
StatusInput.defaultProps = {
  canApprove: true
};
export default StatusInput;