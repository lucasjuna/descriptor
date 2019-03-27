import { combineReducers } from 'redux';
import { reducer as oidcReducer } from 'redux-oidc';
import sellersReducer from './sellers';
import itemsReducer from './items';

const reducers = combineReducers(
  {
    oidc: oidcReducer,
    sellers: sellersReducer,
    items: itemsReducer
  }
);

export default reducers;