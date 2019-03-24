export const fetchAllSellers = () =>
  fetch(`/api/sellers`)
    .then(
      response => response.json(),
      error => console.log('An error occurred.', error)
    )

export const fetchSeller = (userName) =>
  fetch(`/api/sellers/${userName}`)
    .then(
      response => response.ok ? response.json() : Promise.reject({ status: response.status }),
      error => console.log('An error occurred.', error)
    )

export const addSeller = (userName) =>
  fetch(`/api/sellers/${userName}`, {
    method: 'post'
  }).then(
    response => response.json(),
    error => console.log('An error occurred.', error)
  )