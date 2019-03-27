using Descriptor.Domain.Dto;
using Descriptor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Descriptor.Domain.Repositories
{
	public interface ISellerRepository
	{
		Task<IList<SellerDto>> All();
		Task<bool> Exists(string userName);
		Task<SellerDto> Find(string userName);
		void Add(SellerInfo seller);
		Task<long> FindId(string userName);
	}
}
