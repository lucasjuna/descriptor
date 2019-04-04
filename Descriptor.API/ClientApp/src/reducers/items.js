import { LOAD_ITEM_SUCCESS } from "../actions/itemsActions";
import { SESSION_TERMINATED, USER_EXPIRED } from "redux-oidc";

const initialState = {
  loadedItem: {},
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case SESSION_TERMINATED:
    case USER_EXPIRED:
      return Object.assign({}, state, initialState);
    case LOAD_ITEM_SUCCESS:
      return Object.assign({}, state, { loadedItem: action.payload });
    default:
      return state;
  }
}