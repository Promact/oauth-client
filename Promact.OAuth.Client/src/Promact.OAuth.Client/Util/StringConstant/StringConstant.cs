namespace Promact.OAuth.Client.Util.StringConstant
{
    /// <summary>
    /// String Constant class of OAuth client
    /// </summary>
    public class StringConstant : IStringConstant
    {
        #region Base Url
        /// <summary>
        /// Promact Oauth server base url
        /// </summary>
        public string PromactOAuthBaseUrl
        {
            get
            {
                return "http://localhost:35716/";
            }
        }
        #endregion

        #region OAUth API Urls
        /// <summary>
        /// Get promact's list of management url
        /// </summary>
        public string GetListOfPromactManagementDetailsUrl
        {
            get
            {
                return "api/OAuthResponse/managements";
            }
        }

        /// <summary>
        /// Get promact's list of team leader for user slack Id url
        /// </summary>
        public string GetListOfPromactTeamLeaderByUsersSlackIdUrl
        {
            get
            {
                return "api/OAuthResponse/teamLeaders/{0}";
            }
        }

        /// <summary>
        /// Get promact's user details by slack user Id url
        /// </summary>
        public string GetPromactUserDetialBySlackUserIdUrl
        {
            get
            {
                return "api/OAuthResponse/user/{0}";
            }
        }

        /// <summary>
        /// Get promact's user leave allowed details by user slack Id url
        /// </summary>
        public string GetPromactUserLeaveAllowedDetailsUrl
        {
            get
            {
                return "api/OAuthResponse/leaveAllowed/{0}";
            }
        }

        /// <summary>
        /// Get promact's user is admin or not details by user slack Id url
        /// </summary>
        public string GetPromactUserIsAdminOrNotUrl
        {
            get
            {
                return "api/OAuthResponse/userIsAdmin/{0}";
            }
        }

        /// <summary>
        /// Get promact's user details by user Id url
        /// </summary>
        public string GetPromactUserDetailByIdUrl
        {
            get
            {
                return "api/User/{0}/detail";
            }
        }

        /// <summary>
        /// Get promact's users list role by user Id url
        /// </summary>
        public string GetPromactUserRoleUrl
        {
            get
            {
                return "api/user/{0}/role";
            }
        }

        /// <summary>
        /// Get promact's team member details by user Id url
        /// </summary>
        public string GetPromactTeamMembersDetailsByUserIdUrl
        {
            get
            {
                return "api/user/{0}/teammebers";
            }
        }

        /// <summary>
        /// Get promact's list of user in a project by slack group name url 
        /// </summary>
        public string GetPromactProjectUserByGroupNameUrl
        {
            get
            {
                return "api/user/slackChannel/{0}";
            }
        }

        /// <summary>
        /// Get promact's user list by team leader user Id url
        /// </summary>
        public string GetPromactListOfUsersDetailsByTeamLeaderIdUrl
        {
            get
            {
                return "api/User/{0}/project";
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
                return "api/Project/list";
            }
        }

        /// <summary>
        /// Get promact's project details by project Id url
        /// </summary>
        public string GetPromactProjectDetailsByIdUrl
        {
            get
            {
                return "api/Project/{0}/detail";
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
        #endregion
    }
}
