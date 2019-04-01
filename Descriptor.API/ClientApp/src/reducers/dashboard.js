import { LOAD_DASHBOARD_SUCCESS } from "../actions/dashboardActions";

const initialState = {
  items: []
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case LOAD_DASHBOARD_SUCCESS:
      return Object.assign({}, state, { items: action.payload });
    default:
      return state;
  }
}