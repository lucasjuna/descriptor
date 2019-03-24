import { fetchSellers } from '../api/sellersApi'

export const LOAD_SELLERS_START = "descriptor/LOAD_SELLERS_START";
export const LOAD_SELLERS_SUCCESS = "descriptor/LOAD_SELLERS_SUCCESS";

export function loadSellers() {
  return function (dispatch) {
    dispatch({
      type: LOAD_SELLERS_START
    })

    return fetchSellers().then(json =>
      dispatch({
        type: LOAD_SELLERS_SUCCESS,
        payload: json
      })
    )
  }
}