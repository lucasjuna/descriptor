import { LOAD_ITEMS_START, LOAD_ITEMS_SUCCESS } from "../actions/itemsActions";
import { SESSION_TERMINATED, USER_EXPIRED } from "redux-oidc";

const initialState = {
  reviewsResult: {}
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case SESSION_TERMINATED:
    case USER_EXPIRED:
      return Object.assign({}, state, initialState);
    case LOAD_ITEMS_SUCCESS:
      return Object.assign({}, state, { reviewsResult: action.payload });
    default:
      return state;
  }
}