using DevBlog.Web.Models;

namespace DevBlog.Web.Core.Contracts
{
    public interface IBaseService
    {
        /// <summary>
        /// Common method for making API calls.
        /// </summary>
        /// <param name="request">Object with all the information for the request.</param>
        /// <returns>Response information from the API.</returns>
        Task<ResponseDto?> SendAsync(RequestDto request);
    }
}
