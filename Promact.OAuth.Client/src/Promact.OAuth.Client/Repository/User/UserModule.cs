using Promact.OAuth.Client.Util.ExceptionHandler;
using Promact.OAuth.Client.Util.HttpClientWrapper;
using Promact.OAuth.Client.Util.StringConstant;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Promact.OAuth.Client.DomainModel;
using Newtonsoft.Json;
using System.Security.Authentication;

namespace Promact.OAuth.Client.Repository.User
{
    /// <summary>
    /// User Module of OAuth APIs
    /// </summary>
    public class UserModule
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
        public UserModule(IHttpClientService httpClient, IStringConstant stringConstant)
        {
            _httpClient = httpClient;
            _stringConstant = stringConstant;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get promact user details by user slack Id
        /// </summary>
        /// <param name="userSlackId">user's slack Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>User details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<DomainModel.User> GetPromactUserDetailBySlackUserIdAsync(string userSlackId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactUserDetialBySlackUserIdUrl, userSlackId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var user = JsonConvert.DeserializeObject<DomainModel.User>(result.ResponseContent);
                return user;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Get promact's team leader list by user slack Id 
        /// </summary>
        /// <param name="userSlackId">user's slack Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of team leader details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<List<DomainModel.User>> GetListOfPromactTeamLeaderByUsersSlackIdAsync(string userSlackId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetListOfPromactTeamLeaderByUsersSlackIdUrl, userSlackId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var teamLeader = JsonConvert.DeserializeObject<List<DomainModel.User>>(result.ResponseContent);
                return teamLeader;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Get promact's all management list
        /// </summary>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<List<DomainModel.User>> GetListOfPromactManagementDetailsAsync(string userPromactAccessToken)
        {
            var url = _stringConstant.GetListOfPromactManagementDetailsUrl;
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var management = JsonConvert.DeserializeObject<List<DomainModel.User>>(result.ResponseContent);
                return management;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Get promact's user leave allowed detail by slack user Id
        /// </summary>
        /// <param name="userSlackId">user's slack Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>leave allowed details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<LeaveAllowed> GetPromactUserLeaveAllowedDetailsAsync(string userSlackId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactUserLeaveAllowedDetailsUrl, userSlackId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var leaveAllowed = JsonConvert.DeserializeObject<LeaveAllowed>(result.ResponseContent);
                return leaveAllowed;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Get promact's user is admin or not by slack user Id
        /// </summary>
        /// <param name="userSlackId">user's slack Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>true or false</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<bool> GetPromactUserIsAdminOrNotAsync(string userSlackId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactUserIsAdminOrNotUrl, userSlackId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var IsAdmin = JsonConvert.DeserializeObject<bool>(result.ResponseContent);
                return IsAdmin;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Get promact's user details by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>user details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<DomainModel.User> GetPromactUserDetailByIdAsync(string userId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactUserDetailByIdUrl, userId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var user = JsonConvert.DeserializeObject<DomainModel.User>(result.ResponseContent);
                return user;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Get promact's list of user details with role by user slack Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of user role</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<List<UserRole>> GetPromactUserRoleAsync(string userId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactUserRoleUrl, userId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var userRole = JsonConvert.DeserializeObject<List<UserRole>>(result.ResponseContent);
                return userRole;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Get promact's list of team member details with role of project by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of user role</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<List<UserRole>> GetPromactTeamMembersDetailsByUserIdAsync(string userId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactTeamMembersDetailsByUserIdUrl, userId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var userRole = JsonConvert.DeserializeObject<List<UserRole>>(result.ResponseContent);
                return userRole;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Get promact's list of user deatils of project by slack group name of project
        /// </summary>
        /// <param name="slackGroupName"></param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        public async Task<List<DomainModel.User>> GetPromactListOfUserDetailsBySlackGroupNameAsync(string slackGroupName, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactProjectUserByGroupNameUrl, slackGroupName);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var userList = JsonConvert.DeserializeObject<List<DomainModel.User>>(result.ResponseContent);
                return userList;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else
                throw new HttpRequestException(result.ResponseContent);
        }

        /// <summary>
        /// Get promact's list of user details under team leader by team leader Id
        /// </summary>
        /// <param name="teamLeaderId">teamleader's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list od user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        public async Task<List<DomainModel.User>> GetPromactListOfUsersDetailsByTeamLeaderIdAsync(string teamLeaderId, string userPromactAccessToken)
        {
            var url = string.Format(_stringConstant.GetPromactListOfUsersDetailsByTeamLeaderIdUrl, teamLeaderId);
            var result = await _httpClient.GetAsync(userPromactAccessToken, url);
            if (result.Status == System.Net.HttpStatusCode.OK)
            {
                var userList = JsonConvert.DeserializeObject<List<DomainModel.User>>(result.ResponseContent);
                return userList;
            }
            else if (result.Status == System.Net.HttpStatusCode.Forbidden)
                throw new AuthenticationException(_stringConstant.AccessTokenNotMatchedException);
            else if (result.Status == System.Net.HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException(result.ResponseContent);
            else
                throw new UserNotFoundException(_stringConstant.UserNotFoundExceptionMessage);
        }
        #endregion
    }
}
