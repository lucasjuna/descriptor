import { LOAD_ALL_SELLERS_SUCCESS, LOAD_SELLER_SUCCESS, ADD_SELLER_SUCCESS } from "../actions/sellersActions";
import { SESSION_TERMINATED, USER_EXPIRED } from "redux-oidc";

const initialState = {
  list: [],
  loadedSeller: null
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case SESSION_TERMINATED:
    case USER_EXPIRED:
      return Object.assign({}, state, initialState);
    case LOAD_ALL_SELLERS_SUCCESS:
      return Object.assign({}, state, { list: action.payload });
    case LOAD_SELLER_SUCCESS:
    case ADD_SELLER_SUCCESS:
      return Object.assign({}, state, { loadedSeller: action.payload });
    default:
      return state;
  }
}