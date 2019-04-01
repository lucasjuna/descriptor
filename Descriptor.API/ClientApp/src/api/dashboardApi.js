export const fetchDashboard = () =>
    Promise.resolve([
        {
            seller: 'shoppingLeader',
            itemNumber: '5641516',
            description: 'Some really long product description',
            reviewDate: '2019-03-12',
            descriptionId: 112,
            shortDescription: 'nice product',
            reviewer: 'Cam'
        }, {
            seller: 'shoppingLeader',
            itemNumber: '2848715',
            description: 'Man waterproof watercoat',
            reviewDate: '2019-03-09',
            descriptionId: '-',
            shortDescription: '-',
            reviewer: '-'
        }
    ]);

export const fetchReviewersCb = () =>
    Promise.resolve([
        {
            id: 1,
            name: 'Cam'
        }, {
            id: 2,
            name: 'Cam2'
        }
    ]);