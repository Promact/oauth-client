namespace Promact.OAuth.Client.Util.StringConstant
{
    /// <summary>
    /// String Constant interface of OAuth client
    /// </summary>
    public interface IStringConstant
    {
        #region Base Url
        /// <summary>
        /// Promact Oauth server base url
        /// </summary>
        string PromactOAuthBaseUrl { get; }
        #endregion

        #region OAUth API Urls
        /// <summary>
        /// Get promact's list of management url
        /// </summary>
        string GetListOfPromactManagementDetailsUrl { get; }
        /// <summary>
        /// Get promact's list of team leader for user slack Id url
        /// </summary>
        string GetListOfPromactTeamLeaderByUsersSlackIdUrl { get; }
        /// <summary>
        /// Get promact's user details by slack user Id url
        /// </summary>
        string GetPromactUserDetialBySlackUserIdUrl { get; }
        /// <summary>
        /// Get promact's user leave allowed details by user slack Id url
        /// </summary>
        string GetPromactUserLeaveAllowedDetailsUrl { get; }
        /// <summary>
        /// Get promact's user is admin or not details by user slack Id url
        /// </summary>
        string GetPromactUserIsAdminOrNotUrl { get; }
        /// <summary>
        /// Get promact's user details by user Id url
        /// </summary>
        string GetPromactUserDetailByIdUrl { get; }
        /// <summary>
        /// Get promact's users list role by user Id url
        /// </summary>
        string GetPromactUserRoleUrl { get; }
        /// <summary>
        /// Get promact's team member details by user Id url
        /// </summary>
        string GetPromactTeamMembersDetailsByUserIdUrl { get; }
        /// <summary>
        /// Get promact's list of user in a project by slack group name url 
        /// </summary>
        string GetPromactProjectUserByGroupNameUrl { get; }
        /// <summary>
        /// Get promact's user list by team leader user Id url
        /// </summary>
        string GetPromactListOfUsersDetailsByTeamLeaderIdUrl { get; }
        /// <summary>
        /// Get promact's project detail by slack group name url
        /// </summary>
        string GetPromactProjectDetailsByGroupNameUrl { get; }
        /// <summary>
        /// Get promact's list of project url
        /// </summary>
        string GetPromactAllProjectsUrl { get; }
        /// <summary>
        /// Get promact's project details by project Id url
        /// </summary>
        string GetPromactProjectDetailsByIdUrl { get; }
        #endregion

        #region Exception Message
        /// <summary>
        /// User not found exception message
        /// </summary>
        string UserNotFoundExceptionMessage { get; }
        /// <summary>
        /// Group not found exception message
        /// </summary>
        string GroupNotFoundException { get; }
        /// <summary>
        /// Project not found exception message
        /// </summary>
        string ProjectNotFoundException { get; }
        /// <summary>
        /// Access token not match exception message
        /// </summary>
        string AccessTokenNotMatchedException { get; }
        #endregion

        #region Test Cases
        /// <summary>
        /// Ramdon access token for test cases
        /// </summary>
        string AccessTokenForTest { get; }
        /// <summary>
        /// Random user Id for test cases
        /// </summary>
        string UserIdForTest { get; }
        /// <summary>
        /// Random slack user Id for test cases
        /// </summary>
        string SlackUserIdForTest { get; }
        /// <summary>
        /// Random slack group name for test
        /// </summary>
        string SlackGroupNameForTest { get; }
        /// <summary>
        /// Random project Id for test cases
        /// </summary>
        string ProjectIdForTest { get; }
        /// <summary>
        /// Random name of project for test
        /// </summary>
        string RandomProjectNameForTest { get; }
        /// <summary>
        /// HtttpRequestException error message for test
        /// </summary>
        string HttpRequestExceptionErrorMessageForTest { get; }
        /// <summary>
        /// Casual leave random value for test
        /// </summary>
        string CasualLeaveForTest { get; }
        /// <summary>
        /// Random email address for test case
        /// </summary>
        string EmailRandomValueForTest { get; }
        #endregion

        #region Middleware Pipeline
        /// <summary>
        /// OIDC authentication-scheme
        /// </summary>
        string OIDCAuthenticationScheme { get; }

        /// <summary>
        /// SignIn-scheme cookies
        /// </summary>
        string SignInSchemeCookies { get; }

        /// <summary>
        /// Response type code, id_token and token
        /// </summary>
        string ResponseTypeCodeAndIdToken { get; }
        #endregion
    }
}
