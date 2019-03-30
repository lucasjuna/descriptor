using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Persistence.Repositories
{
	public class ProductImageRepository : IProductImageRepository
	{
		private readonly DescriptorContext _context;

		public ProductImageRepository(DescriptorContext context)
		{
			_context = context;
		}

		public void Add(ProductImage image)
		{
			_context.Add(image);
		}
	}
}
