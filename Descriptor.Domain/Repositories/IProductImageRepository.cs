using Descriptor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Domain.Repositories
{
	public interface IProductImageRepository
	{
		void Add(ProductImage image);
	}
}
