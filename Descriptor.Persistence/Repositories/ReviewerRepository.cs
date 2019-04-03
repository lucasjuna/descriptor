using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Descriptor.Persistence.Repositories
{
	public class ReviewerRepository : IReviewerRepository
	{
		private readonly DescriptorContext _context;

		public ReviewerRepository(DescriptorContext context)
		{
			_context = context;
		}

		public void Add(ReviewerInfo reviewer)
		{
			_context.ReviewerInfo.Add(reviewer);
		}

		public async Task<ReviewerInfo> Find(string id)
		{
			return await _context.ReviewerInfo.FindAsync(id);
		}
	}
}
