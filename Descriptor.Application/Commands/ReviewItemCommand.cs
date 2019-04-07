using Descriptor.Domain.Dto;
using Descriptor.Domain.Enumerations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Descriptor.Application.Commands
{
	public class ReviewItemCommand : IRequest
	{
		public string ItemId { get; }
		public long? DescriptionId { get; }
		public ReviewStatus? ItemStatus { get; }
		public ReviewStatus? ImagesStatus { get; }
		public ReviewStatus? PriceStatus { get; }
		public IList<DescriptionDto> Descriptions { get; }

		public ReviewItemCommand(string itemId, long? descriptionId, ReviewStatus? itemStatus, 
			ReviewStatus? imagesStatus, ReviewStatus? priceStatus, IList<DescriptionDto> descriptions)
		{
			ItemId = itemId;
			DescriptionId = descriptionId;
			ItemStatus = itemStatus;
			ImagesStatus = imagesStatus;
			PriceStatus = priceStatus;
			Descriptions = descriptions;
		}
	}
}
