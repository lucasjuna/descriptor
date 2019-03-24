import { combineReducers } from 'redux';
import { reducer as oidcReducer } from 'redux-oidc';
import sellersReducer from './sellers';

const reducers = combineReducers(
  {
    oidc: oidcReducer,
    sellers: sellersReducer
  }
);

export default reducers;