using System.Threading.Tasks;
using Promact.OAuth.Client.Util.HttpClientWrapper;
using Promact.OAuth.Client.Util.StringConstant;
using System.Security.Authentication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using Promact.OAuth.Client.Util.ExceptionHandler;

namespace Promact.OAuth.Client.Repository.Project
{
    /// <summary>
    /// Project Module of OAuth APIs
    /// </summary>
    public class ProjectModule : IProjectModule
    {
        #region Private Variables
        private IHttpClientService _httpClient;
        private IStringConstant _stringConstant;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">Wrapper of http client</param>
        /// <param name="stringConstant">Wrapper of string constant</param>
        public ProjectModule(IHttpClientService httpClient, IStringConstant stringConstant)
        {
            _httpClient = httpClient;
            _stringConstant = stringConstant;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get promact's project details by slack group name of project
        /// </summary>
        /// <param name="slackGroupName"></param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>project detials</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        public async Task<DomainModel.Project> GetPromactProjectDetailsByGroupNameAsync(string slackGroupName, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactProjectDetailsByGroupNameUrl, slackGroupName);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var project = JsonConvert.DeserializeObject<DomainModel.Project>(result.ResponseContent);
                return project;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else
                throw new HttpRequestException(result.ResponseContent);
        }

        /// <summary>
        /// Get promact's list of all project
        /// </summary>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of project details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="ProjectNotFoundException">When project details not found</exception>
        public async Task<List<DomainModel.Project>> GetPromactAllProjectsAsync(string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactAllProjectsUrl);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var projectList = JsonConvert.DeserializeObject<List<DomainModel.Project>>(result.ResponseContent);
                return projectList;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new ProjectNotFoundException(_stringConstant.ProjectNotFoundException);
        }

        /// <summary>
        /// Get promact's project details by project Id
        /// </summary>
        /// <param name="projectId">project Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>project details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="ProjectNotFoundException">When project details not found</exception>
        public async Task<DomainModel.Project> GetPromactProjectDetailsByIdAsync(int projectId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactProjectDetailsByIdUrl, projectId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var project = JsonConvert.DeserializeObject<DomainModel.Project>(result.ResponseContent);
                return project;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new ProjectNotFoundException(_stringConstant.ProjectNotFoundException);
        }
        #endregion
    }
}
