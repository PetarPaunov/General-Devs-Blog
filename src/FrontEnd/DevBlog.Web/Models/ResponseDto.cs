namespace DevBlog.Web.Models
{
    public class ResponseDto
    {
        /// <summary>
        /// Information returned by the service. 
        /// Leaving it an Object so it can be used as a generic response DTO.
        /// </summary>
        public object? Result { get; set; }

        // Indicates whether the request was successful.
        public bool IsSuccess { get; set; }

        // Information about why the request failed.
        public string Message { get; set; } = null!;
    }
}
