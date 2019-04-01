export const fetchDashboard = () =>
    Promise.resolve([
        {
            seller: 'shoppingLeader',
            itemNumber: '5641516',
            description: 'Some really long product description',
            reviewDate: new Date(),
            descriptionId: 112,
            shortDescription: 'nice product',
            reviewer: 'Cam',
            status: 1
        }, {
            seller: 'shoppingLeader',
            itemNumber: '2848715',
            description: 'Man waterproof watercoat',
            reviewDate: new Date(),
            descriptionId: '-',
            shortDescription: '-',
            reviewer: '-',
            status: 2
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