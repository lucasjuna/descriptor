using Descriptor.Application;
using Descriptor.Application.Dto.Ebay;
using Descriptor.Application.Services;
using Descriptor.Infrastructure.Requests;
using Descriptor.Infrastructure.Responses;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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

		public async Task<UserInfo> GetUser(string userName)
		{
			var request = new GetUserRequest(_appSettings.Value.EbayApiToken, userName);
			var result = await ExecuteRequest<GetUserRequest, GetUserResponse>("GetUser", request);
			if (result?.User != null)
				result.User.UserName = userName;
			return result.User;
		}

		private async Task<TResponse> ExecuteRequest<TRequest, TResponse>(string callName, TRequest request)
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
				requestMessage.Headers.Add("X-EBAY-API-CALL-NAME", callName);
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
