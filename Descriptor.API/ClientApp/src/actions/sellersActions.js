import { fetchAllSellers, fetchSeller, addSeller } from '../api/sellersApi'
import { confirmAlert } from 'react-confirm-alert';
import history from '../history';
import { loadItems } from './itemsActions';

export const LOAD_ALL_SELLERS_START = "descriptor/LOAD_ALL_SELLERS_START";
export const LOAD_ALL_SELLERS_SUCCESS = "descriptor/LOAD_ALL_SELLERS_SUCCESS";
export const LOAD_SELLER_START = "descriptor/LOAD_SELLER_START";
export const LOAD_SELLER_SUCCESS = "descriptor/LOAD_SELLER_SUCCESS";
export const ADD_SELLER_START = "descriptor/ADD_SELLER_START";
export const ADD_SELLER_SUCCESS = "descriptor/ADD_SELLER_SUCCESS";
export const CLEAR_SELLER = "descriptor/CLEAR_SELLER";

export const loadAllSellers = () => {
  return (dispatch) => {
    dispatch({
      type: LOAD_ALL_SELLERS_START
    })

    return fetchAllSellers().then(json =>
      dispatch({
        type: LOAD_ALL_SELLERS_SUCCESS,
        payload: json
      })
    )
  }
}

export const loadSeller = (userName) => {
  return (dispatch) => {
    dispatch({
      type: LOAD_SELLER_START
    })

    return fetchSeller(userName).then(json =>
      dispatch({
        type: LOAD_SELLER_SUCCESS,
        payload: json
      })
    ).catch(error => {
      if (error.status === 404) {
        return confirmAlert({
          message: 'New Seller. Load Items?',
          buttons: [
            {
              label: 'Yes',
              onClick: () => dispatch(addNewSeller(userName))
            },
            {
              label: 'No',
            }
          ]
        });
      }
    })
  }
}

export const addNewSeller = (userName) => {
  return (dispatch) => {
    dispatch({
      type: ADD_SELLER_START
    })

    return addSeller(userName).then(json => {
      history.push('/load-items/new-seller');
      dispatch({
        type: ADD_SELLER_SUCCESS,
        payload: json
      });
      dispatch(loadItems(userName));
    })
  }
}

export const clearSeller = () => {
  return {
    type: CLEAR_SELLER
  }
}