import { combineReducers } from 'redux';
import { reducer as oidcReducer } from 'redux-oidc';
import sellersReducer from './sellers';
import itemsReducer from './items';
import dashboardReducer from './dashboard';

const reducers = combineReducers(
  {
    oidc: oidcReducer,
    sellers: sellersReducer,
    items: itemsReducer,
    dashboard: dashboardReducer
  }
);

export default reducers;