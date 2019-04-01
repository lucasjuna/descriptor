import { fetchDashboard } from '../api/dashboardApi';

export const LOAD_DASHBOARD_START = "descriptor/LOAD_DASHBOARD_START";
export const LOAD_DASHBOARD_SUCCESS = "descriptor/LOAD_DASHBOARD_SUCCESS";

export const loadDashboard = (userName) => {
  return (dispatch) => {
    dispatch({
      type: LOAD_DASHBOARD_START
    });

    return fetchDashboard(userName).then(json => {
      dispatch({
        type: LOAD_DASHBOARD_SUCCESS,
        payload: json
      })
    })
  }
}