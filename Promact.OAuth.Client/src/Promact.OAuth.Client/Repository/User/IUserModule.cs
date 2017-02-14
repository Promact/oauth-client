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
        /// Access token to be set before using any method
        /// </summary>
        string AccessToken { get; set; }
        /// <summary>
        /// Get promact user details by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <returns>User details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<DomainModel.User> GetPromactUserDetailByUserIdAsync(string userId);
        /// <summary>
        /// Get promact's team leader list by user Id 
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <returns>list of team leader details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<List<DomainModel.User>> GetListOfPromactTeamLeaderByUserIdAsync(string userId);
        /// <summary>
        /// Get promact's all management list
        /// </summary>
        /// <returns>list of user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<List<DomainModel.User>> GetListOfPromactManagementDetailsAsync();
        /// <summary>
        /// Get promact's user leave allowed detail by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <returns>leave allowed details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<DomainModel.LeaveAllowed> GetPromactUserLeaveAllowedDetailsAsync(string userId);
        /// <summary>
        /// Get promact's user is admin or not by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <returns>true or false</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<bool> GetPromactUserIsAdminOrNotAsync(string userId);
        /// <summary>
        /// Get promact's user details by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <returns>user details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<DomainModel.User> GetPromactUserDetailByIdAsync(string userId);
        /// <summary>
        /// Get promact's list of user details with role by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <returns>list of user role</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<List<DomainModel.UserRole>> GetPromactUserRoleAsync(string userId);
        /// <summary>
        /// Get promact's list of team member details with role of project by user Id
        /// </summary>
        /// <param name="userId">user's Id</param>
        /// <returns>list of user role</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<List<DomainModel.UserRole>> GetPromactTeamMembersDetailsByUserIdAsync(string userId);
        /// <summary>
        /// Get promact's list of user deatils of project by slack group name of project
        /// </summary>
        /// <param name="slackGroupName"></param>
        /// <returns>list of user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<List<DomainModel.User>> GetPromactListOfUserDetailsBySlackGroupNameAsync(string slackGroupName);
        /// <summary>
        /// Get promact's list of user details under team leader by team leader Id
        /// </summary>
        /// <param name="teamLeaderId">teamleader's Id</param>
        /// <returns>list od user</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="UserNotFoundException">When user details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<List<DomainModel.User>> GetPromactListOfUsersDetailsByTeamLeaderIdAsync(string teamLeaderId);
    }
}
