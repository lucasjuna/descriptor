using Descriptor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Descriptor.Domain.Repositories
{
	public interface IReviewerRepository
	{
		void Add(ReviewerInfo reviewer);
		Task<ReviewerInfo> Find(string id);
	}
}
