import { LOAD_ALL_SELLERS_SUCCESS, LOAD_SELLER_SUCCESS, ADD_SELLER_SUCCESS, CLEAR_SELLER, LOAD_ITEMS_START, LOAD_ITEMS_SUCCESS, LOAD_ITEMS_FAILURE } from "../actions/sellersActions";
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
    case LOAD_ITEMS_SUCCESS:
      return Object.assign({}, state, {
        loadedSeller: Object.assign({}, state.loadedSeller, {
          total: action.payload.total,
          escalated: action.payload.escalated
        })
      });
    case CLEAR_SELLER:
      return Object.assign({}, state, { loadedSeller: null });
    case LOAD_ITEMS_START:
      return Object.assign({}, state, {
        itemsLoading: true,
        reviewsResult: []
      });
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