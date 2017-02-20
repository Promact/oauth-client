using System;

namespace Promact.OAuth.Client.Test.StringConstantTest
{
    public class StringConstantTest : IStringConstantTest
    {
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
                return Environment.GetEnvironmentVariable("PromactOAuthClientId");
            }
        }

        /// <summary>
        /// Promact App Integration Test ClientSecret
        /// </summary>
        public string PromactOAuthClientSecret
        {
            get
            {
                return Environment.GetEnvironmentVariable("PromactOAuthClientSecret");
            }
        }
        #endregion
    }
}
