import store from '../store';

export const fetchInitReviewer = () =>
  fetch(`/api/reviewers/init-reviewer`, {
    method: 'put',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  })

  export const fetchAllReviewers = () =>
  fetch(`/api/reviewers`, {
    method: 'get',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  }).then(
    response => response.ok ? response.json() : Promise.reject({ status: response.status, error: response.json() }),
    error => console.log('An error occurred.', error)
  )
