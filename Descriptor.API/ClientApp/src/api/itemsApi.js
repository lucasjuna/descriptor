import store from '../store';

export const fetchLoadItem = (itemId) =>
  fetch(`/api/items/${itemId}`, {
    method: 'get',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  }).then(
    response => response.ok ? response.json() : Promise.reject({ status: response.status, error: response.json() }),
    error => console.log('An error occurred.', error)
  )

export const fetchSubmitReview = (itemId, item) =>
  fetch(`/api/items/${itemId}`, {
    method: 'put',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`,
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })