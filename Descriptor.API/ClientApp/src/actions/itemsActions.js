import { fetchLoadItems } from '../api/itemsApi'
import { toast } from 'react-toastify';

export const LOAD_ITEMS_START = "descriptor/LOAD_ITEMS_START";
export const LOAD_ITEMS_SUCCESS = "descriptor/LOAD_ITEMS_SUCCESS";
export const LOAD_ITEMS_FAILURE = "descriptor/LOAD_ITEMS_FAILURE";

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