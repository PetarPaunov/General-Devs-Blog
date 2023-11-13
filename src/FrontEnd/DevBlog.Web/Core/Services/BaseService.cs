namespace DevBlog.Web.Core.Services
{
    using DevBlog.Web.Core.Contracts;
    using DevBlog.Web.Models;
    using Newtonsoft.Json;
    using System.Net;
    using System.Text;
    using static DevBlog.Web.Constants.BaseServiceConstants;
    using static DevBlog.Web.Utility.StaticDetails;

    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Common method for making API calls.
        /// </summary>
        /// <param name="apiRequest">Object with all the information for the request.</param>
        /// <returns>Response information from the API.</returns>
        public async Task<ResponseDto?> SendAsync(RequestDto apiRequest)
        {
            try
            {

                HttpClient client = this.httpClientFactory.CreateClient(HttpClientName);

                var message = new HttpRequestMessage();

                message.Headers.Add(AcceptMediaType, MediaType);
                // token 

                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert
                            .SerializeObject(apiRequest.Data), Encoding.UTF8, MediaType);
                }

                switch (apiRequest.RequestType)
                {
                    case RequestType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case RequestType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case RequestType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default: 
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage? apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ResponseDto() { IsSuccess = false, Message = StatusCodeNotFound};
                    case HttpStatusCode.Forbidden:
                        return new ResponseDto() { IsSuccess = false, Message = StatusCodeForbidden };
                    case HttpStatusCode.Unauthorized:
                        return new ResponseDto() { IsSuccess = false, Message = StatusCodeUnauthorized };
                    case HttpStatusCode.InternalServerError:
                        return new ResponseDto() { IsSuccess = false, Message = StatusCodeInternalServerError };
                    default:
                        var apiContect = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContect);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    Message = ex.Message,
                    IsSuccess = false,
                };

                return dto;
            }
        }
    }
}
