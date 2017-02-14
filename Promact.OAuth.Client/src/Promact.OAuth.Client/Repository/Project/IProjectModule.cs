using System.Threading.Tasks;
using System.Security.Authentication;
using System.Net.Http;
using System.Collections.Generic;
using Promact.OAuth.Client.Util.ExceptionHandler;

namespace Promact.OAuth.Client.Repository.Project
{
    /// <summary>
    /// Interface of Project Module
    /// </summary>
    public interface IProjectModule
    {
        /// <summary>
        /// Access token to be set before using any method
        /// </summary>
        string AccessToken { get; set; }
        /// <summary>
        /// Get promact's project details by slack group name of project
        /// </summary>
        /// <param name="slackGroupName"></param>
        /// <returns>project detials</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<DomainModel.Project> GetPromactProjectDetailsByGroupNameAsync(string slackGroupName);
        /// <summary>
        /// Get promact's list of all project
        /// </summary>
        /// <returns>list of project details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="ProjectNotFoundException">When project details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<List<DomainModel.Project>> GetPromactAllProjectsAsync();
        /// <summary>
        /// Get promact's project details by project Id
        /// </summary>
        /// <param name="projectId">project Id</param>
        /// <returns>project details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="ProjectNotFoundException">When project details not found</exception>
        /// <exception cref="AccessTokenNullableException">When access token will be null</exception>
        Task<DomainModel.Project> GetPromactProjectDetailsByIdAsync(int projectId);
    }
}
