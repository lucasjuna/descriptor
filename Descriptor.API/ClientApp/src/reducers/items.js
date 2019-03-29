import { LOAD_ITEMS_START, LOAD_ITEMS_SUCCESS, LOAD_ITEMS_FAILURE } from "../actions/itemsActions";
import { SESSION_TERMINATED, USER_EXPIRED } from "redux-oidc";

const initialState = {
  reviewsResult: {},
  itemsLoading: false
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case SESSION_TERMINATED:
    case USER_EXPIRED:
      return Object.assign({}, state, initialState);
    case LOAD_ITEMS_START:
      return Object.assign({}, state, { itemsLoading: true });
    case LOAD_ITEMS_SUCCESS:
      return Object.assign({}, state, {
        itemsLoading: false,
        reviewsResult: action.payload
      });
    case LOAD_ITEMS_FAILURE:
      return Object.assign({}, state, { itemsLoading: false });
    default:
      return state;
  }
}