using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Authentication;
using System.Net.Http;
using Promact.OAuth.Client.Util.ExceptionHandler;

namespace Promact.OAuth.Client.Repository.User
{
    /// <summary>
    /// Interface of User Module
    /// </summary>
    public interface IUserModule
    {
        /// <summary>
        /// Get promact user details by user slack Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>User details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<DomainModel.User> GetPromactUserDetailBySlackUserIdAsync(string userId, string userPromactAccessToken);
        /// <summary>
        /// Get promact's team leader list by user slack Id 
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of team leader details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<List<DomainModel.User>> GetListOfPromactTeamLeaderByUsersSlackIdAsync(string userId, string userPromactAccessToken);
        /// <summary>
        /// Get promact's all management list
        /// </summary>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<List<DomainModel.User>> GetListOfPromactManagementDetailsAsync(string userPromactAccessToken);
        /// <summary>
        /// Get promact's user leave allowed detail by slack user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>leave allowed details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<DomainModel.LeaveAllowed> GetPromactUserLeaveAllowedDetailsAsync(string userId, string userPromactAccessToken);
        /// <summary>
        /// Get promact's user is admin or not by slack user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>true or false</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<bool> GetPromactUserIsAdminOrNotAsync(string userId, string userPromactAccessToken);
        /// <summary>
        /// Get promact's user details by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>user details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<DomainModel.User> GetPromactUserDetailByIdAsync(string userId, string userPromactAccessToken);
        /// <summary>
        /// Get promact's list of user details with role by user slack Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of user role</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<List<DomainModel.UserRole>> GetPromactUserRoleAsync(string userId, string userPromactAccessToken);
        /// <summary>
        /// Get promact's list of team member details with role of project by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of user role</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<List<DomainModel.UserRole>> GetPromactTeamMembersDetailsByUserIdAsync(string userId, string userPromactAccessToken);
        /// <summary>
        /// Get promact's list of user deatils of project by slack group name of project
        /// </summary>
        /// <param name="slackGroupName"></param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        Task<List<DomainModel.User>> GetPromactListOfUserDetailsBySlackGroupNameAsync(string slackGroupName, string userPromactAccessToken);
        /// <summary>
        /// Get promact's list of user details under team leader by team leader Id
        /// </summary>
        /// <param name="teamLeaderId">teamleader's Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list od user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        Task<List<DomainModel.User>> GetPromactListOfUsersDetailsByTeamLeaderIdAsync(string teamLeaderId, string userPromactAccessToken);
    }
}
