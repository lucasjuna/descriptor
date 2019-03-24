import { LOAD_SELLERS_SUCCESS } from "../actions/sellersActions";
import { SESSION_TERMINATED, USER_EXPIRED } from "redux-oidc";

const initialState = {
  list: []
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case SESSION_TERMINATED:
    case USER_EXPIRED:
      return Object.assign({}, state, { list: [] });
    case LOAD_SELLERS_SUCCESS:
      return Object.assign({}, state, { list: action.payload });
    default:
      return state;
  }
}