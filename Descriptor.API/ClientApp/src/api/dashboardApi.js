import store from '../store';

export const fetchDashboard = (userName) =>
  fetch(`/api/sellers/${userName}/items`, {
    method: 'get',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  }).then(
    response => response.ok ? response.json() : Promise.reject({ status: response.status, error: response.json() }),
    error => console.log('An error occurred.', error)
  )

export const fetchReviewersCb = () =>
  Promise.resolve([
  ]);