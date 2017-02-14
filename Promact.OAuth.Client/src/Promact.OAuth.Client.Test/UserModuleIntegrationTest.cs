using Promact.OAuth.Client.Repository.User;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Promact.OAuth.Client.Util.ExceptionHandler;
using System.Net.Http;
using Promact.OAuth.Client.Repository.BaseUrlSetUp;

namespace Promact.OAuth.Client.Test
{
    public class UserModuleIntegrationTest : IntegrationBaseProvider
    {
        #region Private Variables
        private readonly IUserModule _userModule;
        #endregion

        #region Constructor
        public UserModuleIntegrationTest() : base()
        {
            _userModule = serviceProvider.GetService<IUserModule>();
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.PromactOAuthUrl;
            _userModule.AccessToken = _userScopeResponse.AccessToken;
        }
        #endregion

        #region Test Cases
        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsync()
        {
            var result = await _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.AdminIdForIntegrationTest);
            Assert.Equal(result.Email, _stringConstant.AdminEmailForTest);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(() =>
            _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsync()
        {
            var result = await _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.UserIdForIntegrationTest);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetListOfPromactManagementDetailsAsync
        /// </summary>
        [Fact]
        public async Task GetListOfPromactManagementDetailsAsync()
        {
            var result = await _userModule.GetListOfPromactManagementDetailsAsync();
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetListOfPromactManagementDetailsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactManagementDetailsAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(()=>
            _userModule.GetListOfPromactManagementDetailsAsync());
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetListOfPromactManagementDetailsAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactManagementDetailsAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetListOfPromactManagementDetailsAsync());
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserLeaveAllowedDetailsAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserLeaveAllowedDetailsAsync()
        {
            var result = await _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.UserIdForIntegrationTest);
            Assert.Equal(result.CasualLeave, 2);
        }

        /// <summary>
        /// Integration Test GetPromactUserLeaveAllowedDetailsAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserLeaveAllowedDetailsAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserLeaveAllowedDetailsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserLeaveAllowedDetailsAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserLeaveAllowedDetailsAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactUserLeaveAllowedDetailsAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsync()
        {
            var result = await _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.AdminIdForIntegrationTest);
            Assert.Equal(result, true);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsync()
        {
            var result = await _userModule.GetPromactUserDetailByIdAsync(_stringConstant.AdminIdForIntegrationTest);
            Assert.Equal(result.Email, _stringConstant.AdminEmailForTest);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserDetailByIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserDetailByIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetPromactUserDetailByIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsync()
        {
            var result = await _userModule.GetPromactUserRoleAsync(_stringConstant.AdminIdForIntegrationTest);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserRoleAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserRoleAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetPromactUserRoleAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsync()
        {
            var result = await _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.AdminIdForIntegrationTest);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUserDetailsBySlackGroupNameAsync
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUserDetailsBySlackGroupNameAsync()
        {
            _userModule.AccessToken = _projectScopeResponse.AccessToken;
            var result = await _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.ProjectGroupNameForTest);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUserDetailsBySlackGroupNameAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUserDetailsBySlackGroupNameAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(()=>
            _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.ProjectGroupNameForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUserDetailsBySlackGroupNameAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUserDetailsBySlackGroupNameAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.ProjectGroupNameForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsync()
        {
            var result = await _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.TeamLeaderIdForIntegrationTest);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsyncAccessTokenNullableException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAsync<AccessTokenNullableException>(() =>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.RandomUserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }
        #endregion
    }
}
