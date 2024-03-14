using Newtonsoft.Json;
using Vegapunk.FrontEnd.Shaka.Models;
using Vegapunk.FrontEnd.Shaka.Service.IService;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Vegapunk.FrontEnd.Shaka.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            // for this DI to work add to program.cs -->
            // builder.Services.AddHttpClient();
            // builder.Services.AddScoped<IBaseService, BaseService>();
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _httpClientFactory.CreateClient("Vegapunk");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");

			message.RequestUri = new Uri(requestDto.Url);
            if(requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage? response = null;

            switch (requestDto.ApiType)
            {
                case Utility.StaticData.ApiType.GET:
                    message.Method = HttpMethod.Get;
                    break;
                case Utility.StaticData.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case Utility.StaticData.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case Utility.StaticData.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    break;
            }
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			response = await client.SendAsync(message);
            try
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Forbidden" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "InternalServerError" };
                    default:
                        var apiContent = await response.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent) ?? new ResponseDto();
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }

        }
    }
}
