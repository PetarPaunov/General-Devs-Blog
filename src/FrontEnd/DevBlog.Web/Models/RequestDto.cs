namespace DevBlog.Web.Models
{
    public class RequestDto
    {
        /// <summary>
        /// The request method.
        /// Default -> GET.
        /// </summary>
        public string RequestType { get; set; } = "GET";

        /// <summary>
        /// The url to which the request goes.
        /// </summary>
        public string Url { get; set; } = null!;

        /// <summary>
        /// The data sent with the request.
        /// Leaving it an Object so it can be used with any data type.
        /// </summary>
        public object Data { get; set; } = null!;

        /// <summary>
        /// User authorization token.
        /// </summary>

        public string AccessToken { get; set; } = null!;

    }
}
