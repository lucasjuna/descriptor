export const fetchSellers = () =>
  fetch(`/api/sellers`)
    .then(
      response => response.json(),
      error => console.log('An error occurred.', error)
    )