using Descriptor.Domain.Dto;
using Descriptor.Domain.Entities;
using Descriptor.Domain.Repositories;
using Descriptor.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descriptor.Persistence.Repositories
{
	public class SellerRepository : ISellerRepository
	{
		private readonly DescriptorContext _context;

		public SellerRepository(DescriptorContext context)
		{
			_context = context;
		}

		public void Add(SellerInfo seller)
		{
			_context.SellerInfo.Add(seller);
		}

		public async Task<IList<SellerDto>> All()
		{
			return await _context.SellerInfo.Select(x => new SellerDto
			{
				EbaySellerUserName = x.EbaySellerUserName
			}).ToListAsync();
		}

		public async Task<bool> Exists(string userName)
		{
			if (userName == null)
				throw new ArgumentNullException(nameof(userName));

			return await _context.SellerInfo.AnyAsync(x => x.EbaySellerUserName == userName.ToUpper());
		}

		public async Task<SellerDto> Find(string userName)
		{
			if (userName == null)
				throw new ArgumentNullException(nameof(userName));

			return await _context.SellerInfo.Where(x => x.EbaySellerUserName == userName.ToUpper())
				.Select(x => new SellerDto
				{
					EbaySellerUserName = x.EbaySellerUserName,
					Address = x.Address1,
					EmailAddress = x.EmailAddress,
					FirstName = x.FirstName,
					LastName = x.LastName
				}).SingleOrDefaultAsync();
		}
	}
}
