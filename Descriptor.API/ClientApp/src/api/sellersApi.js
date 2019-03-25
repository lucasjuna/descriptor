import store from '../store';

export const fetchAllSellers = () =>
  fetch(`/api/sellers`, {
    method: 'get',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  }).then(
    response => response.json(),
    error => console.log('An error occurred.', error)
  )

export const fetchSeller = (userName) =>
  fetch(`/api/sellers/${userName}`, {
    method: 'get',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  }).then(
    response => response.ok ? response.json() : Promise.reject({ status: response.status }),
    error => console.log('An error occurred.', error)
  )

export const addSeller = (userName) =>
  fetch(`/api/sellers/${userName}`, {
    method: 'post',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  }).then(
    response => response.json(),
    error => console.log('An error occurred.', error)
  )