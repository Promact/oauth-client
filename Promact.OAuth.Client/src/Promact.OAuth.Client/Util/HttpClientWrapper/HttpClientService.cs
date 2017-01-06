using Promact.OAuth.Client.DomainModel;
using Promact.OAuth.Client.Util.StringConstant;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Promact.OAuth.Client.Util.HttpClientWrapper
{
    /// <summary>
    /// Http client wrapper
    /// </summary>
    public class HttpClientService : IHttpClientService
    {
        #region Private Variables
        private HttpClient _httpClient;
        private readonly IStringConstant _stringConstant;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HttpClientService(IStringConstant stringConstant)
        {
            _stringConstant = stringConstant;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// GetAsync method of http client
        /// </summary>
        /// <param name="accessToken">user's promact access token</param>
        /// <param name="contentUrl">content url of request</param>
        /// <returns></returns>
        public async Task<RequestAndReponse> GetAsync(string accessToken, string contentUrl)
        {
            RequestAndReponse requestResponse = new RequestAndReponse();
            //string responseContent = null;
            try
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(_stringConstant.PromactOAuthBaseUrl);
                // Added access token to request header if provided by user
                if (!String.IsNullOrEmpty(accessToken))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessToken);
                }
                var response = await _httpClient.GetAsync(contentUrl);
                requestResponse.Status = response.StatusCode;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    requestResponse.ResponseContent = response.Content.ReadAsStringAsync().Result;
                }
                _httpClient.Dispose();
            }
            catch (HttpRequestException ex)
            {
                requestResponse.Status = System.Net.HttpStatusCode.GatewayTimeout;
                requestResponse.ResponseContent = ex.Message;
            }
            return requestResponse;
        }
        #endregion
    }
}
