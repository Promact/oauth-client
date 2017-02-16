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

        #region Test Cases
        /// <summary>
        /// Ramdon access token for test cases
        /// </summary>
        public string AccessTokenForTest
        {
            get
            {
                return "a0a21d71-9f21-41e7-9904-aabe57599554";
            }
        }

        /// <summary>
        /// Random user Id for test cases
        /// </summary>
        public string UserIdForTest
        {
            get
            {
                return "7092802a-206e-4ce4-8192-f086a1ec1fb6";
            }
        }

        /// <summary>
        /// Random slack group name for test
        /// </summary>
        public string SlackGroupNameForTest
        {
            get
            {
                return "OAuth-Test";
            }
        }

        /// <summary>
        /// Random project Id for test cases
        /// </summary>
        public string ProjectIdForTest
        {
            get
            {
                return "1";
            }
        }

        /// <summary>
        /// Random name of project for test
        /// </summary>
        public string RandomProjectNameForTest
        {
            get
            {
                return "something";
            }
        }

        /// <summary>
        /// HtttpRequestException error message for test
        /// </summary>
        public string HttpRequestExceptionErrorMessageForTest
        {
            get
            {
                return "Exception of type 'System.Net.Http.HttpRequestException' was thrown.";
            }
        }

        /// <summary>
        /// Casual leave random value for test
        /// </summary>
        public string CasualLeaveForTest
        {
            get
            {
                return "9";
            }
        }

        /// <summary>
        /// Random email address for test case
        /// </summary>
        public string EmailRandomValueForTest
        {
            get
            {
                return "siddhartha@promactinfo.com";
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

        #region Integration Test Cases
        /// <summary>
        /// String Id of Admin for Test
        /// </summary>
        public string AdminIdForIntegrationTest
        {
            get
            {
                return "8d29efae-d747-4fc6-a7f1-13f687bd5d67";
            }
        }

        /// <summary>
        /// String Id of User for Test
        /// </summary>
        public string UserIdForIntegrationTest
        {
            get
            {
                return "9cdc7982-25b9-45a4-afdc-6b13e6e53ca6";
            }
        }

        /// <summary>
        /// Random Id for Test cases
        /// </summary>
        public string RandomUserIdForTest
        {
            get
            {
                return "dasfnsjkdnflkasmdlka";
            }
        }

        /// <summary>
        /// String Id of TeamLeader for Test
        /// </summary>
        public string TeamLeaderIdForIntegrationTest
        {
            get
            {
                return "ea18f1db-6fa5-4050-8930-138e0b1ff21d";
            }
        }

        /// <summary>
        /// String Email address of Admin
        /// </summary>
        public string AdminEmailForTest
        {
            get
            {
                return "admin@promactinfo.com";
            }
        }

        /// <summary>
        /// String Project group name for test
        /// </summary>
        public string ProjectGroupNameForTest
        {
            get
            {
                return "Slash-Command";
            }
        }

        /// <summary>
        /// Random Url for test
        /// </summary>
        public string RandomUrlForTest
        {
            get
            {
                return "http://localhost:1234/";
            }
        }

        /// <summary>
        /// Promact Oauth Server Base Url
        /// </summary>
        public string PromactOAuthUrl
        {
            get
            {
                return "https://oauth.promactinfo.com/";
            }
        }

        /// <summary>
        /// Promact App Integration Test ClientId
        /// </summary>
        public string PromactOAuthClientId
        {
            get
            {
                return "OOKK4SVDYQ8XRUU";
            }
        }

        /// <summary>
        /// Promact App Integration Test ClientSecret
        /// </summary>
        public string PromactOAuthClientSecret
        {
            get
            {
                return "icbbHra92LEzIS5AHE6NuuR0Qk20Oo";
            }
        }
        #endregion
    }
}
