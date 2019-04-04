import { fetchAllSellers, fetchSeller, addSeller, fetchLoadItems } from '../api/sellersApi'
import { confirmAlert } from 'react-confirm-alert';
import history from '../history';
import { toast } from 'react-toastify';

export const LOAD_ALL_SELLERS_START = "descriptor/LOAD_ALL_SELLERS_START";
export const LOAD_ALL_SELLERS_SUCCESS = "descriptor/LOAD_ALL_SELLERS_SUCCESS";
export const LOAD_SELLER_START = "descriptor/LOAD_SELLER_START";
export const LOAD_SELLER_SUCCESS = "descriptor/LOAD_SELLER_SUCCESS";
export const ADD_SELLER_START = "descriptor/ADD_SELLER_START";
export const ADD_SELLER_SUCCESS = "descriptor/ADD_SELLER_SUCCESS";
export const CLEAR_SELLER = "descriptor/CLEAR_SELLER";
export const LOAD_ITEMS_START = "descriptor/LOAD_ITEMS_START";
export const LOAD_ITEMS_SUCCESS = "descriptor/LOAD_ITEMS_SUCCESS";
export const LOAD_ITEMS_FAILURE = "descriptor/LOAD_ITEMS_FAILURE";

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
    ).catch(r => r.error.then(e => toast.error(e.message)))
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
    ).catch(r => {
      if (r.status === 404) {
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
      } else {
        r.error.then(e => toast.error(e.message))
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
    }).catch(r => r.error.then(e => toast.error(e.message)))
  }
}

export const loadItems = (userName) => {
  return (dispatch) => {
    dispatch({
      type: LOAD_ITEMS_START
    })

    return fetchLoadItems(userName).then(json =>
      dispatch({
        type: LOAD_ITEMS_SUCCESS,
        payload: json
      })
    ).catch(r => {
      dispatch({
        type: LOAD_ITEMS_FAILURE,
      });
      r.error.then(e => toast.error(e.message));
    })
  }
}

export const clearSeller = () => {
  return {
    type: CLEAR_SELLER
  }
}