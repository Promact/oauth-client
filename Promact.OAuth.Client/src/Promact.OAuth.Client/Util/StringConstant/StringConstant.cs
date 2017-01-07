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
        /// Random slack user Id for test cases
        /// </summary>
        public string SlackUserIdForTest
        {
            get
            {
                return "U0HJKJ4";
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
        /// GetListOfPromactManagementDetailsAsync Random Value For Test cases
        /// </summary>
        public string GetListOfPromactManagementDetailsAsyncRandomValueForTest
        {
            get
            {
                return "[{\"firstName\":\"Siddhartha\",\"lastName\":null,\"isActive\":false,\"numberOfCasualLeave\":0.0,\"numberOfSickLeave\":0.0,\"joiningDate\":\"0001-01-01T00:00:00\",\"slackUserId\":\"U0HJ49KJ4\",\"slackUserName\":null,\"projects\":null,\"createdBy\":null,\"createdDateTime\":\"0001-01-01T00:00:00\",\"updatedBy\":null,\"updatedDateTime\":\"0001-01-01T00:00:00\",\"id\":\"c2e7cb63-63fb-4c00-a490-a03a8675f66e\",\"userName\":null,\"normalizedUserName\":null,\"email\":\"siddhartha@promactinfo.com\",\"normalizedEmail\":null,\"emailConfirmed\":false,\"passwordHash\":null,\"securityStamp\":null,\"concurrencyStamp\":\"a8aa0e04-dfa3-4589-98e8-b191517e607e\",\"phoneNumber\":null,\"phoneNumberConfirmed\":false,\"twoFactorEnabled\":false,\"lockoutEnd\":null,\"lockoutEnabled\":false,\"accessFailedCount\":0,\"roles\":[],\"claims\":[],\"logins\":[]}]";
            }
        }

        /// <summary>
        /// GetListOfPromactTeamLeaderByUsersSlackIdAsync Random Value For Test cases
        /// </summary>
        public string GetListOfPromactTeamLeaderByUsersSlackIdAsyncRandomValueForTest
        {
            get
            {
                return "[{\"firstName\":null,\"lastName\":null,\"isActive\":false,\"numberOfCasualLeave\":0.0,\"numberOfSickLeave\":0.0,\"joiningDate\":\"0001-01-01T00:00:00\",\"slackUserId\":\"U0525LCJR\",\"slackUserName\":null,\"projects\":null,\"createdBy\":null,\"createdDateTime\":\"0001-01-01T00:00:00\",\"updatedBy\":null,\"updatedDateTime\":\"0001-01-01T00:00:00\",\"id\":\"65310614-8092-4514-8c1e-9801a1fff253\",\"userName\":\"roshni@promactinfo.com\",\"normalizedUserName\":null,\"email\":\"roshni@promactinfo.com\",\"normalizedEmail\":null,\"emailConfirmed\":false,\"passwordHash\":null,\"securityStamp\":null,\"concurrencyStamp\":\"ffe4ebcc-11b3-4978-99a9-abcab28028a9\",\"phoneNumber\":null,\"phoneNumberConfirmed\":false,\"twoFactorEnabled\":false,\"lockoutEnd\":null,\"lockoutEnabled\":false,\"accessFailedCount\":0,\"roles\":[],\"claims\":[],\"logins\":[]}]";
            }
        }

        /// <summary>
        /// GetPromactAllProjectsAsync Random Value For Test cases
        /// </summary>
        public string GetPromactAllProjectsAsyncRandomValueForTest
        {
            get
            {
                return "[{\"id\":1,\"name\":\"Slack Custom Integration\",\"slackChannelName\":\"Slash-Command\",\"isActive\":true,\"teamLeaderId\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"createdBy\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"createdDate\":\"2016-12-16\",\"updatedBy\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"updatedDate\":null,\"teamLeader\":{\"Id\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"FirstName\":\"Siddhartha\",\"LastName\":\"Shaw\",\"IsActive\":true,\"Role\":\"TeamLeader\",\"NumberOfCasualLeave\":9.0,\"NumberOfSickLeave\":4.0,\"JoiningDate\":\"2016-07-17T18:30:00\",\"SlackUserName\":\"siddhartha\",\"SlackUserId\":\"U0HJ49KJ4\",\"Email\":\"siddhartha@promactinfo.com\",\"Password\":null,\"UserName\":\"siddhartha@promactinfo.com\",\"UniqueName\":\"Siddhartha-siddhartha@promactinfo.com\",\"RoleName\":null},\"applicationUsers\":[{\"Id\":\"ab68f87f-fe83-4b75-9b87-b029ec477c2d\",\"FirstName\":\"Admin\",\"LastName\":\"Promact\",\"IsActive\":true,\"Role\":\"Employee\",\"NumberOfCasualLeave\":0.0,\"NumberOfSickLeave\":0.0,\"JoiningDate\":\"0001-01-01T00:00:00\",\"SlackUserName\":\"roshni\",\"SlackUserId\":\"U0525LCJR\",\"Email\":\"roshni@promactinfo.com\",\"Password\":null,\"UserName\":\"roshni@promactinfo.com\",\"UniqueName\":\"Admin-roshni@promactinfo.com\",\"RoleName\":null}]},{\"id\":2,\"name\":\"something\",\"slackChannelName\":\"asdasdasd\",\"isActive\":true,\"teamLeaderId\":\"ab68f87f-fe83-4b75-9b87-b029ec477c2d\",\"createdBy\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"createdDate\":\"2017-01-03\",\"updatedBy\":null,\"updatedDate\":null,\"teamLeader\":{\"Id\":\"ab68f87f-fe83-4b75-9b87-b029ec477c2d\",\"FirstName\":\"Admin\",\"LastName\":\"Promact\",\"IsActive\":true,\"Role\":\"TeamLeader\",\"NumberOfCasualLeave\":0.0,\"NumberOfSickLeave\":0.0,\"JoiningDate\":\"0001-01-01T00:00:00\",\"SlackUserName\":\"roshni\",\"SlackUserId\":\"U0525LCJR\",\"Email\":\"roshni@promactinfo.com\",\"Password\":null,\"UserName\":\"roshni@promactinfo.com\",\"UniqueName\":\"Admin-roshni@promactinfo.com\",\"RoleName\":null},\"applicationUsers\":[{\"Id\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"FirstName\":\"Siddhartha\",\"LastName\":\"Shaw\",\"IsActive\":true,\"Role\":\"Employee\",\"NumberOfCasualLeave\":9.0,\"NumberOfSickLeave\":4.0,\"JoiningDate\":\"2016-07-17T18:30:00\",\"SlackUserName\":\"siddhartha\",\"SlackUserId\":\"U0HJ49KJ4\",\"Email\":\"siddhartha@promactinfo.com\",\"Password\":null,\"UserName\":\"siddhartha@promactinfo.com\",\"UniqueName\":\"Siddhartha-siddhartha@promactinfo.com\",\"RoleName\":null}]}]";
            }
        }

        /// <summary>
        /// GetPromactListOfUsersDetailsByTeamLeaderIdAsync Random Value For Test cases
        /// </summary>
        public string GetPromactListOfUsersDetailsByTeamLeaderIdAsyncRandomValueForTest
        {
            get
            {
                return "[{\"Id\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"FirstName\":\"Siddhartha\",\"LastName\":\"Shaw\",\"IsActive\":true,\"Role\":\"TeamLeader\",\"NumberOfCasualLeave\":9.0,\"NumberOfSickLeave\":4.0,\"JoiningDate\":\"2016-07-17T18:30:00\",\"SlackUserName\":\"siddhartha\",\"SlackUserId\":\"U0HJ49KJ4\",\"Email\":\"siddhartha@promactinfo.com\",\"Password\":null,\"UserName\":\"siddhartha@promactinfo.com\",\"UniqueName\":\"Siddhartha-siddhartha@promactinfo.com\",\"RoleName\":null},{\"Id\":\"ab68f87f-fe83-4b75-9b87-b029ec477c2d\",\"FirstName\":\"Admin\",\"LastName\":\"Promact\",\"IsActive\":true,\"Role\":\"Employee\",\"NumberOfCasualLeave\":0.0,\"NumberOfSickLeave\":0.0,\"JoiningDate\":\"0001-01-01T00:00:00\",\"SlackUserName\":\"roshni\",\"SlackUserId\":\"U0525LCJR\",\"Email\":\"roshni@promactinfo.com\",\"Password\":null,\"UserName\":\"roshni@promactinfo.com\",\"UniqueName\":\"Admin-roshni@promactinfo.com\",\"RoleName\":null}]";
            }
        }

        /// <summary>
        /// GetPromactListOfUserDetailsBySlackGroupNameAsync Random Value For Test cases
        /// </summary>
        public string GetPromactListOfUserDetailsBySlackGroupNameAsyncRandomValueForTest
        {
            get
            {
                return "[{\"Id\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"FirstName\":\"Siddhartha\",\"LastName\":\"Shaw\",\"IsActive\":true,\"Role\":null,\"NumberOfCasualLeave\":0.0,\"NumberOfSickLeave\":0.0,\"JoiningDate\":\"0001-01-01T00:00:00\",\"SlackUserName\":null,\"SlackUserId\":\"U0HJ49KJ4\",\"Email\":\"siddhartha@promactinfo.com\",\"Password\":null,\"UserName\":\"siddhartha@promactinfo.com\",\"UniqueName\":\"Siddhartha-siddhartha@promactinfo.com\",\"RoleName\":null}]";
            }
        }

        /// <summary>
        /// GetPromactProjectDetailsByGroupNameAsync Random Value For Test cases
        /// </summary>
        public string GetPromactProjectDetailsByGroupNameAsyncRandomValueForTest
        {
            get
            {
                return "{\"id\":2,\"name\":\"something\",\"slackChannelName\":\"asdasdasd\",\"isActive\":true,\"teamLeaderId\":\"ab68f87f-fe83-4b75-9b87-b029ec477c2d\",\"createdBy\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"createdDate\":null,\"updatedBy\":null,\"updatedDate\":null,\"teamLeader\":null,\"applicationUsers\":null}";
            }
        }

        /// <summary>
        /// GetPromactProjectDetailsByIdAsync Random Value For Test cases
        /// </summary>
        public string GetPromactProjectDetailsByIdAsyncRandomValueForTest
        {
            get
            {
                return "{\"id\":1,\"name\":\"Slack Custom Integration\",\"slackChannelName\":\"Slash-Command\",\"isActive\":true,\"teamLeaderId\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"createdBy\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"createdDate\":\"2016-12-16\",\"updatedBy\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"updatedDate\":null,\"teamLeader\":{\"Id\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"FirstName\":\"Siddhartha\",\"LastName\":\"Shaw\",\"IsActive\":true,\"Role\":\"TeamLeader\",\"NumberOfCasualLeave\":9.0,\"NumberOfSickLeave\":4.0,\"JoiningDate\":\"2016-07-17T18:30:00\",\"SlackUserName\":\"siddhartha\",\"SlackUserId\":\"U0HJ49KJ4\",\"Email\":\"siddhartha@promactinfo.com\",\"Password\":null,\"UserName\":\"siddhartha@promactinfo.com\",\"UniqueName\":\"Siddhartha-siddhartha@promactinfo.com\",\"RoleName\":null},\"applicationUsers\":[{\"Id\":\"ab68f87f-fe83-4b75-9b87-b029ec477c2d\",\"FirstName\":\"Admin\",\"LastName\":\"Promact\",\"IsActive\":true,\"Role\":\"Employee\",\"NumberOfCasualLeave\":0.0,\"NumberOfSickLeave\":0.0,\"JoiningDate\":\"0001-01-01T00:00:00\",\"SlackUserName\":\"roshni\",\"SlackUserId\":\"U0525LCJR\",\"Email\":\"roshni@promactinfo.com\",\"Password\":null,\"UserName\":\"roshni@promactinfo.com\",\"UniqueName\":\"Admin-roshni@promactinfo.com\",\"RoleName\":null}]}";
            }
        }

        /// <summary>
        /// GetPromactTeamMembersDetailsByUserIdAsync Random Value For Test cases
        /// </summary>
        public string GetPromactTeamMembersDetailsByUserIdAsyncRandomValueForTest
        {
            get
            {
                return "[{\"userId\":null,\"userName\":\"siddhartha@promactinfo.com\",\"name\":\"Siddhartha Shaw\",\"role\":\"TeamLeader\"},{\"userId\":null,\"userName\":\"roshni@promactinfo.com\",\"name\":\"Admin Promact\",\"role\":\"Admin\"}]";
            }
        }

        /// <summary>
        /// GetPromactUserDetailByIdAsync Random Value For Test cases
        /// </summary>
        public string GetPromactUserDetailByIdAsyncRandomValueForTest
        {
            get
            {
                return "{\"Id\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"FirstName\":\"Siddhartha\",\"LastName\":\"Shaw\",\"IsActive\":true,\"Role\":\"Admin\",\"NumberOfCasualLeave\":9.0,\"NumberOfSickLeave\":4.0,\"JoiningDate\":\"2016-07-17T18:30:00\",\"SlackUserName\":\"siddhartha\",\"SlackUserId\":\"U0HJ49KJ4\",\"Email\":\"siddhartha@promactinfo.com\",\"Password\":null,\"UserName\":\"siddhartha@promactinfo.com\",\"UniqueName\":\"Siddhartha-siddhartha@promactinfo.com\",\"RoleName\":null}";
            }
        }

        /// <summary>
        /// GetPromactUserDetailBySlackUserIdAsync Random Value For Test cases
        /// </summary>
        public string GetPromactUserDetailBySlackUserIdAsyncRandomValueForTest
        {
            get
            {
                return "{\"firstName\":\"Siddhartha\",\"lastName\":\"Shaw\",\"isActive\":false,\"numberOfCasualLeave\":0.0,\"numberOfSickLeave\":0.0,\"joiningDate\":\"0001-01-01T00:00:00\",\"slackUserId\":\"U0HJ49KJ4\",\"slackUserName\":null,\"projects\":null,\"createdBy\":null,\"createdDateTime\":\"0001-01-01T00:00:00\",\"updatedBy\":null,\"updatedDateTime\":\"0001-01-01T00:00:00\",\"id\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"userName\":null,\"normalizedUserName\":null,\"email\":\"siddhartha@promactinfo.com\",\"normalizedEmail\":null,\"emailConfirmed\":false,\"passwordHash\":null,\"securityStamp\":null,\"concurrencyStamp\":\"51d6e35e-9fa4-45a8-99b4-ea6d97bde229\",\"phoneNumber\":null,\"phoneNumberConfirmed\":false,\"twoFactorEnabled\":false,\"lockoutEnd\":null,\"lockoutEnabled\":false,\"accessFailedCount\":0,\"roles\":[],\"claims\":[],\"logins\":[]}";
            }
        }

        /// <summary>
        /// GetPromactUserIsAdminOrNotAsync Random Value For Test cases
        /// </summary>
        public string GetPromactUserIsAdminOrNotAsyncRandomValueForTest
        {
            get
            {
                return "true";
            }
        }

        /// <summary>
        /// GetPromactUserLeaveAllowedDetailsAsync Random Value For Test cases
        /// </summary>
        public string GetPromactUserLeaveAllowedDetailsAsyncRandomValueForTest
        {
            get
            {
                return "{\"casualLeave\":9.0,\"sickLeave\":4.0}";
            }
        }

        /// <summary>
        /// GetPromactUserRoleAsync Random Value For Test cases
        /// </summary>
        public string GetPromactUserRoleAsyncRandomValueForTest
        {
            get
            {
                return "[{\"userId\":\"7092802a-206e-4ce4-8192-f086a1ec1fb6\",\"userName\":\"siddhartha@promactinfo.com\",\"name\":\"Siddhartha Shaw\",\"role\":\"Admin\"},{\"userId\":\"ab68f87f-fe83-4b75-9b87-b029ec477c2d\",\"userName\":\"roshni@promactinfo.com\",\"name\":\"Admin Promact\",\"role\":\"Admin\"}]";
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
    }
}
