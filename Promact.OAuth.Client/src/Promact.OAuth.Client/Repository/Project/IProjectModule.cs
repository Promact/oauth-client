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
        /// Get promact's project details by slack group name of project
        /// </summary>
        /// <param name="slackGroupName"></param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>project detials</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        Task<DomainModel.Project> GetPromactProjectDetailsByGroupNameAsync(string slackGroupName, string userPromactAccessToken);
        /// <summary>
        /// Get promact's list of all project
        /// </summary>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>list of project details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="ProjectNotFoundException">When project details not found</exception>
        Task<List<DomainModel.Project>> GetPromactAllProjectsAsync(string userPromactAccessToken);
        /// <summary>
        /// Get promact's project details by project Id
        /// </summary>
        /// <param name="projectId">project Id</param>
        /// <param name="userPromactAccessToken">user's promact access token</param>
        /// <returns>project details</returns>
        /// <exception cref="AuthenticationException">When user's access token is not allowed</exception>
        /// <exception cref="HttpRequestException">When promact oauth server is closed</exception>
        /// <exception cref="ProjectNotFoundException">When project details not found</exception>
        Task<DomainModel.Project> GetPromactProjectDetailsByIdAsync(int projectId, string userPromactAccessToken);
    }
}
