import store from '../store';

export const fetchLoadItems = (userName) =>
  fetch(`/api/items/${userName}`, {
    method: 'put',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  }).then(
    response => response.json(),
    error => console.log('An error occurred.', error)
  )