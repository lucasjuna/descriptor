import { fetchLoadItem } from '../api/itemsApi'
import { toast } from 'react-toastify';

export const LOAD_ITEM_START = "descriptor/LOAD_ITEM_START";
export const LOAD_ITEM_SUCCESS = "descriptor/LOAD_ITEM_SUCCESS";
export const LOAD_ITEM_FAILURE = "descriptor/LOAD_ITEM_FAILURE";

export const loadItem = (itemId) => {
  return (dispatch) => {
    dispatch({
      type: LOAD_ITEM_START
    })

    return fetchLoadItem(itemId).then(json =>
      dispatch({
        type: LOAD_ITEM_SUCCESS,
        payload: json
      })
    )
  }
}