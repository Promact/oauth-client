using Promact.OAuth.Client.DomainModel;
using System.Threading.Tasks;

namespace Promact.OAuth.Client.Util.HttpClientWrapper
{
    /// <summary>
    /// Http client service interface
    /// </summary>
    public interface IHttpClientService
    {
        /// <summary>
        /// Http Client getasync method
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="contentUrl"></param>
        /// <returns></returns>
        Task<RequestAndReponse> GetAsync(string accessToken, string contentUrl);
    }
}
