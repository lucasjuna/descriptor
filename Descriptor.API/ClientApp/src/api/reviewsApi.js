import store from '../store';

export const fetchInitReviewer = () =>
  fetch(`/api/reviews/init-reviewer`, {
    method: 'put',
    headers: {
      Authorization: `Bearer ${store.getState().oidc.user.access_token}`
    }
  })