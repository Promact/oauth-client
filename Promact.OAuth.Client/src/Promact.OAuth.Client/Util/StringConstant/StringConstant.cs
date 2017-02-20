using System;

namespace Promact.OAuth.Client.Util.StringConstant
{
    /// <summary>
    /// String Constant class of OAuth client
    /// </summary>
    public class StringConstant : IStringConstant
    {
        #region OAUth API Urls
        /// <summary>
        /// Get promact's list of management url
        /// </summary>
        public string GetListOfPromactManagementDetailsUrl
        {
            get
            {
                return "api/users/managements";
            }
        }

        /// <summary>
        /// Get promact's list of team leader for user slack Id url
        /// </summary>
        public string GetListOfPromactTeamLeaderByUsersSlackIdUrl
        {
            get
            {
                return "api/users/teamLeaders/{0}";
            }
        }

        /// <summary>
        /// Get promact's user details by slack user Id url
        /// </summary>
        public string GetPromactUserDetialBySlackUserIdUrl
        {
            get
            {
                return "api/users/user/{0}";
            }
        }

        /// <summary>
        /// Get promact's user leave allowed details by user slack Id url
        /// </summary>
        public string GetPromactUserLeaveAllowedDetailsUrl
        {
            get
            {
                return "api/users/leaveAllowed/{0}";
            }
        }

        /// <summary>
        /// Get promact's user is admin or not details by user slack Id url
        /// </summary>
        public string GetPromactUserIsAdminOrNotUrl
        {
            get
            {
                return "api/users/userIsAdmin/{0}";
            }
        }

        /// <summary>
        /// Get promact's user details by user Id url
        /// </summary>
        public string GetPromactUserDetailByIdUrl
        {
            get
            {
                return "api/users/{0}/detail";
            }
        }

        /// <summary>
        /// Get promact's users list role by user Id url
        /// </summary>
        public string GetPromactUserRoleUrl
        {
            get
            {
                return "api/users/{0}/role";
            }
        }

        /// <summary>
        /// Get promact's team member details by user Id url
        /// </summary>
        public string GetPromactTeamMembersDetailsByUserIdUrl
        {
            get
            {
                return "api/users/{0}/teammembers";
            }
        }

        /// <summary>
        /// Get promact's list of user in a project by slack group name url 
        /// </summary>
        public string GetPromactProjectUserByGroupNameUrl
        {
            get
            {
                return "api/users/slackChannel/{0}";
            }
        }

        /// <summary>
        /// Get promact's user list by team leader user Id url
        /// </summary>
        public string GetPromactListOfUsersDetailsByTeamLeaderIdUrl
        {
            get
            {
                return "api/users/{0}/project";
            }
        }

        /// <summary>
        /// Get promact's project detail by slack group name url
        /// </summary>
        public string GetPromactProjectDetailsByGroupNameUrl
        {
            get
            {
                return "api/project/{0}";
            }
        }

        /// <summary>
        /// Get promact's list of project url
        /// </summary>
        public string GetPromactAllProjectsUrl
        {
            get
            {
                return "api/project/list";
            }
        }

        /// <summary>
        /// Get promact's project details by project Id url
        /// </summary>
        public string GetPromactProjectDetailsByIdUrl
        {
            get
            {
                return "api/project/{0}/detail";
            }
        }
        #endregion

        #region Exception Message
        /// <summary>
        /// User not found exception message
        /// </summary>
        public string UserNotFoundExceptionMessage
        {
            get
            {
                return "User does not exist in Promact OAuth server.";
            }
        }

        /// <summary>
        /// Group not found exception message
        /// </summary>
        public string GroupNotFoundException
        {
            get
            {
                return "Slack project doesnot exist in Promact OAuth server.";
            }
        }

        /// <summary>
        /// Project not found exception message
        /// </summary>
        public string ProjectNotFoundException
        {
            get
            {
                return "Project doesnot exist in Promact OAuth server";
            }
        }

        /// <summary>
        /// Access token not match exception message
        /// </summary>
        public string AccessTokenNotMatchedException
        {
            get
            {
                return "Your access token doesnot match with Proamct OAuth server access token.";
            }
        }

        /// <summary>
        /// Message to be send when access token is null
        /// </summary>
        public string AccessTokenNullableExceptionMessage
        {
            get
            {
                return "Access token is null.";
            }
        }
        #endregion

        #region Middleware Pipeline
        /// <summary>
        /// OIDC authentication-scheme
        /// </summary>
        public string OIDCAuthenticationScheme
        {
            get
            {
                return "oidc";
            }
        }

        /// <summary>
        /// SignIn-scheme cookies
        /// </summary>
        public string SignInSchemeCookies
        {
            get
            {
                return "Cookies";
            }
        }

        /// <summary>
        /// Response type code, id_token and token
        /// </summary>
        public string ResponseTypeCodeAndIdToken
        {
            get
            {
                return "code id_token token";
            }
        }
        #endregion
    }
}
