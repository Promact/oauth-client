using Promact.OAuth.Client.Repository.User;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Promact.OAuth.Client.Util.ExceptionHandler;
using Promact.OAuth.Client.Util.StringConstant;
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
        }
        #endregion

        #region Test Cases
        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsync()
        {
            var result = await _userModule.GetPromactUserDetailBySlackUserIdAsync(_stringConstant.AdminIdForIntegrationTest,
                _userScopeResponse.AccessToken);
            Assert.Equal(result.Email, _stringConstant.AdminEmailForTest);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync for exception UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(() =>
            _userModule.GetPromactUserDetailBySlackUserIdAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync for exception HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserDetailBySlackUserIdAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsync()
        {
            var result = await _userModule.GetListOfPromactTeamLeaderByUsersSlackIdAsync(_stringConstant.UserIdForIntegrationTest, 
                _userScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetListOfPromactTeamLeaderByUsersSlackIdAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
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
            _userModule.GetListOfPromactTeamLeaderByUsersSlackIdAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetListOfPromactManagementDetailsAsync
        /// </summary>
        [Fact]
        public async Task GetListOfPromactManagementDetailsAsync()
        {
            var result = await _userModule.GetListOfPromactManagementDetailsAsync(_userScopeResponse.AccessToken);
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
            _userModule.GetListOfPromactManagementDetailsAsync(_userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserLeaveAllowedDetailsAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserLeaveAllowedDetailsAsync()
        {
            var result = await _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.UserIdForIntegrationTest, 
                _userScopeResponse.AccessToken);
            Assert.Equal(result.CasualLeave, 2);
        }

        /// <summary>
        /// Integration Test GetPromactUserLeaveAllowedDetailsAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserLeaveAllowedDetailsAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
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
            _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsync()
        {
            var result = await _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.AdminIdForIntegrationTest, 
                _userScopeResponse.AccessToken);
            Assert.Equal(result, true);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
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
            _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsync()
        {
            var result = await _userModule.GetPromactUserDetailByIdAsync(_stringConstant.AdminIdForIntegrationTest, 
                _userScopeResponse.AccessToken);
            Assert.Equal(result.Email, _stringConstant.AdminEmailForTest);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserDetailByIdAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
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
            _userModule.GetPromactUserDetailByIdAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsync()
        {
            var result = await _userModule.GetPromactUserRoleAsync(_stringConstant.AdminIdForIntegrationTest, 
                _userScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserRoleAsync(_stringConstant.RandomUserIdForTest, _userScopeResponse.AccessToken));
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
            _userModule.GetPromactUserRoleAsync(_stringConstant.RandomUserIdForTest, _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsync()
        {
            var result = await _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.AdminIdForIntegrationTest, 
                _userScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
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
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.RandomUserIdForTest, 
            _userScopeResponse.AccessToken));
            Assert.NotNull(result);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUserDetailsBySlackGroupNameAsync
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUserDetailsBySlackGroupNameAsync()
        {
            var result = await _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.ProjectGroupNameForTest, 
                _projectScopeResponse.AccessToken);
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
            _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.ProjectGroupNameForTest, 
            _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsync()
        {
            var result = await _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.TeamLeaderIdForIntegrationTest,
                _userScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.RandomUserIdForTest,
            _userScopeResponse.AccessToken));
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
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.RandomUserIdForTest,
            _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }
        #endregion
    }
}
