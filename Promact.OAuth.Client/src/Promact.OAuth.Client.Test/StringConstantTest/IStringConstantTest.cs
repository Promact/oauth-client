namespace Promact.OAuth.Client.Test.StringConstantTest
{
    public interface IStringConstantTest
    {
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

        #region Integration Test Cases
        /// <summary>
        /// String Id of Admin for Test
        /// </summary>
        string AdminIdForIntegrationTest { get; }
        /// <summary>
        /// String Id of User for Test
        /// </summary>
        string UserIdForIntegrationTest { get; }
        /// <summary>
        /// Random Id for Test cases
        /// </summary>
        string RandomUserIdForTest { get; }
        /// <summary>
        /// String Id of TeamLeader for Test
        /// </summary>
        string TeamLeaderIdForIntegrationTest { get; }
        /// <summary>
        /// String Email address of Admin
        /// </summary>
        string AdminEmailForTest { get; }
        /// <summary>
        /// String Project group name for test
        /// </summary>
        string ProjectGroupNameForTest { get; }
        /// <summary>
        /// Random Url for test
        /// </summary>
        string RandomUrlForTest { get; }
        /// <summary>
        /// Promact Oauth Server Base Url
        /// </summary>
        string PromactOAuthUrl { get; }
        /// <summary>
        /// Promact App Integration Test ClientId
        /// </summary>
        string PromactOAuthClientId { get; }
        /// <summary>
        /// Promact App Integration Test ClientSecret
        /// </summary>
        string PromactOAuthClientSecret { get; }
        #endregion
    }
}
