﻿using Descriptor.Application;
using Descriptor.Application.Dto.Ebay;
using Descriptor.Application.Exceptions;
using Descriptor.Application.Services;
using Descriptor.Infrastructure.Requests;
using Descriptor.Infrastructure.Responses;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Descriptor.Infrastructure.Responses.FindItemsAdvancedResponse;

namespace Descriptor.Infrastructure.Services
{
	public class EbayFindingService : IEbayFindingService
	{
		private readonly HttpClient _client;
		private readonly IOptions<AppSettings> _appSettings;

		public EbayFindingService(HttpClient client, IOptions<AppSettings> appSettings)
		{
			_client = client;
			_appSettings = appSettings;
		}

		public async Task<ICollection<ItemDto>> FindItemsAdvanced(string userName)
		{
			const int EntriesPerPage = 100;
			const int MaxPages = 100;
			int pageNumber = 1;
			var itemList = new List<Item>();

			int loaded = 0;
			do
			{
				var request = new FindItemsAdvancedRequest(userName, EntriesPerPage, pageNumber, true);
				var result = await ExecuteRequest<FindItemsAdvancedRequest, FindItemsAdvancedResponse>(request);

				if (result.Ack.ToUpper() != "SUCCESS")
					throw new EbayException($"Ebay API error: {result.ErrorMessage?.Error?.Message}");

				itemList.AddRange(result.SearchResult);
				loaded = result.SearchResult.Count;
				pageNumber++;
			}
			while (loaded == EntriesPerPage && pageNumber <= MaxPages);

			var itemInfo = itemList.Select(x => new ItemDto()
			{
				ItemId = x.ItemId,
				Country = x.Country,
				EbayDescription = x.Title,
				EbayItemLocation = x.Location,
				EbayViewItemUrl = x.ViewItemUrl
			}).ToList();
			return itemInfo;
		}

		private async Task<TResponse> ExecuteRequest<TRequest, TResponse>(TRequest request)
			where TRequest : BaseEbayFindingRequest
			where TResponse : BaseEbayFindingResponse
		{
			string requestXml;
			using (var writer = new StringWriter())
			{
				var serializer = new XmlSerializer(typeof(TRequest));
				serializer.Serialize(writer, request);
				requestXml = writer.ToString();
			}

			HttpResponseMessage response;
			using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "services/search/FindingService/v1"))
			{
				requestMessage.Headers.Add("X-EBAY-SOA-REQUEST-DATA-FORMAT", "XML");
				requestMessage.Headers.Add("X-EBAY-SOA-OPERATION-NAME", request.OperationName);
				requestMessage.Headers.Add("X-EBAY-SOA-SERVICE-NAME", "FindingService");
				requestMessage.Headers.Add("X-EBAY-SOA-GLOBAL-ID", "EBAY-US");
				requestMessage.Headers.Add("X-EBAY-SOA-SECURITY-APPNAME", _appSettings.Value.EbayApiAppId);
				requestMessage.Content = new StringContent(requestXml, Encoding.UTF8, "application/xml");
				response = await _client.SendAsync(requestMessage);
			}

			using (var stream = await response.Content.ReadAsStreamAsync())
			{
				var serializer = new XmlSerializer(typeof(TResponse));
				var result = serializer.Deserialize(stream) as TResponse;
				return result;
			}
		}
	}
}
