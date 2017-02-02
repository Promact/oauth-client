namespace Promact.OAuth.Client.DomainModel
{
    /// <summary>
    /// Request response application class
    /// </summary>
    public class RequestAndReponse
    {
        /// <summary>
        /// Http response content
        /// </summary>
        public string ResponseContent { get; set; }

        /// <summary>
        /// Http response status code
        /// </summary>
        public System.Net.HttpStatusCode Status { get; set; }
    }
}
