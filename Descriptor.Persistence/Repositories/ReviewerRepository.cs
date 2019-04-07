using Descriptor.Domain.Dto;
using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<IList<ReviewerDto>> All()
		{
			return await _context.ReviewerInfo.Select(x => new ReviewerDto
			{
				Id = x.Id,
				FirstName = x.FirstName,
				LastName = x.LastName
			}).OrderBy(x => x.FirstName)
			.ThenBy(x => x.LastName)
			.ToListAsync();
		}

		public async Task<ReviewerInfo> Find(string id)
		{
			return await _context.ReviewerInfo.FindAsync(id);
		}
	}
}
