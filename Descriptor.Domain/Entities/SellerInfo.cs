using System;

namespace Descriptor.Domain.Entities
{
	public class SellerInfo
	{
		public long Id { get; set; }
		public string EbaySellerUserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Address3 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public int Zip { get; set; }
		public string EmailAddress { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime LastProcessDate { get; set; }
		public int TotalItemsReviewed { get; set; }
		public int TotalItemsAccepted { get; set; }
		public int TotalItemsRejected { get; set; }
		public int TotalItemsInReview { get; set; }
	}
}
