using Descriptor.Application;
using Descriptor.Application.Dto.Ebay;
using Descriptor.Application.Exceptions;
using Descriptor.Application.Services;
using Descriptor.Infrastructure.Requests;
using Descriptor.Infrastructure.Responses;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Descriptor.Infrastructure.Services
{
	public class EbayTradingService : IEbayTradingService
	{
		private readonly HttpClient _client;
		private readonly IOptions<AppSettings> _appSettings;

		public EbayTradingService(HttpClient client, IOptions<AppSettings> appSettings)
		{
			_client = client;
			_appSettings = appSettings;
		}

		public async Task<UserDto> GetUser(string userName)
		{
			var request = new GetUserRequest(_appSettings.Value.EbayApiToken, userName);
			var result = await ExecuteRequest<GetUserRequest, GetUserResponse>(request);

			if (result.Ack.ToUpper() != "SUCCESS")
				throw new EbayException($"Ebay API error: {result.Errors?.ShortMessage}");

			return new UserDto
			{
				City = result.User.RegistrationAddress?.CityName,
				State = result.User.RegistrationAddress?.StateOrProvince,
				Zip = result.User.RegistrationAddress?.PostalCode,
				Street = result.User.RegistrationAddress?.Street,
				Street1 = result.User.RegistrationAddress?.Street1,
				Street2 = result.User.RegistrationAddress?.Street2,
				Email = result.User.Email,
				RegistrationDate = result.User.RegistrationDate,
				UserName = result.User.UserID
			};
		}

		public async Task<ItemDto> GetItem(string itemId)
		{
			var request = new GetItemRequest(_appSettings.Value.EbayApiToken, itemId);
			request.OutputSelector = "Item.SKU,Item.BuyItNowPrice,Item.Seller.UserID,Item.CrossBorderTrade,Item.PictureDetails.PictureURL";
			var result = await ExecuteRequest<GetItemRequest, GetItemResponse>(request);

			if (result.Ack.ToUpper() != "SUCCESS")
				throw new EbayException($"Ebay API error: {result.Errors?.ShortMessage}");

			return new ItemDto
			{
				ItemId = itemId,
				EbayBuyItNowPrice = result.Item.BuyItNowPrice?.Value ?? 0,
				EbayBuyItNowCurrencyID = result.Item.BuyItNowPrice?.CurrencyID,
				SKU = result.Item.SKU,
				UserId = result.Item.Seller.UserID,
				CrossboarderTrade = result.Item.CrossBorderTrade,
				PictureURLs = result.Item.PictureDetails
			};
		}

		private async Task<TResponse> ExecuteRequest<TRequest, TResponse>(TRequest request)
			where TRequest : BaseEbayTradingRequest
			where TResponse : BaseEbayTradingResponse
		{
			string requestXml;
			using (var writer = new StringWriter())
			{
				var serializer = new XmlSerializer(typeof(TRequest));
				serializer.Serialize(writer, request);
				requestXml = writer.ToString();
			}

			HttpResponseMessage response;
			using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "ws/api.dll"))
			{
				requestMessage.Headers.Add("X-EBAY-API-CALL-NAME", request.OperationName);
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
