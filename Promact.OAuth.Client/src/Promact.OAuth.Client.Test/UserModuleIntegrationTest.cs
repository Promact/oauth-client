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
        private readonly IStringConstant _stringConstant;
        #endregion

        #region Constructor
        public UserModuleIntegrationTest() : base()
        {
            _userModule = serviceProvider.GetService<IUserModule>();
            _stringConstant = serviceProvider.GetService<IStringConstant>();
            Repository.BaseUrlSetUp.PromactBaseUrl.PromactOAuthUrl = "http://localhost:35716/";
        }
        #endregion

        #region Test Cases
        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsync()
        {
            var result = await _userModule.GetPromactUserDetailBySlackUserIdAsync("U7800454", _userScopeResponse.AccessToken);
            Assert.Equal(result.Email, "roshni@promactinfo.com");
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync for exception UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(() =>
            _userModule.GetPromactUserDetailBySlackUserIdAsync("1df5sd5fs5d", _userScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync for exception HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserDetailBySlackUserIdAsync("1df5sd5fs5d", _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsync()
        {
            var result = await _userModule.GetListOfPromactTeamLeaderByUsersSlackIdAsync("U7800454", _userScopeResponse.AccessToken);
            Assert.Equal(result.Count, 1);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetListOfPromactTeamLeaderByUsersSlackIdAsync("f5gd51fgd", _userScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetListOfPromactTeamLeaderByUsersSlackIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetListOfPromactTeamLeaderByUsersSlackIdAsync("f5gd51fgd", _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetListOfPromactManagementDetailsAsync
        /// </summary>
        [Fact]
        public async Task GetListOfPromactManagementDetailsAsync()
        {
            var result = await _userModule.GetListOfPromactManagementDetailsAsync(_userScopeResponse.AccessToken);
            Assert.Equal(result.Count, 2);
        }

        /// <summary>
        /// Integration Test GetListOfPromactManagementDetailsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactManagementDetailsAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
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
            var result = await _userModule.GetPromactUserLeaveAllowedDetailsAsync("U7800454",_userScopeResponse.AccessToken);
            Assert.NotNull(result.CasualLeave);
        }

        /// <summary>
        /// Integration Test GetPromactUserLeaveAllowedDetailsAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserLeaveAllowedDetailsAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync("sd4f1s2d1f2s", _userScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserLeaveAllowedDetailsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserLeaveAllowedDetailsAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync("sd4f1s2d1f2s", _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsync()
        {
            var result = await _userModule.GetPromactUserIsAdminOrNotAsync("U7800454", _userScopeResponse.AccessToken);
            Assert.Equal(result, true);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserIsAdminOrNotAsync("d541f5sd1f5s", _userScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserIsAdminOrNotAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserIsAdminOrNotAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserIsAdminOrNotAsync("d541f5sd1f5s", _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsync()
        {
            var result = await _userModule.GetPromactUserDetailByIdAsync("724f2dd4-49a4-4f6b-8edb-f957f1cbbc23", _userScopeResponse.AccessToken);
            Assert.Equal(result.Email, "roshni@promactinfo.com");
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserDetailByIdAsync("df1s5d1fs51df5s1d5f1s5d1s", _userScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserDetailByIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailByIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserDetailByIdAsync("df1s5d1fs51df5s1d5f1s5d1s", _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsync()
        {
            var result = await _userModule.GetPromactUserRoleAsync("724f2dd4-49a4-4f6b-8edb-f957f1cbbc23", _userScopeResponse.AccessToken);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactUserRoleAsync("7dsa4f5sadfs4df5s4df5s4d5ssdf1", _userScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactUserRoleAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactUserRoleAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserRoleAsync("7dsa4f5sadfs4df5s4df5s4d5ssdf1", _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsync()
        {
            var result = await _userModule.GetPromactTeamMembersDetailsByUserIdAsync("724f2dd4-49a4-4f6b-8edb-f957f1cbbc23", _userScopeResponse.AccessToken);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync("df1s5d4fg5sfg51sdf5g1s5d1f5sddfs", _userScopeResponse.AccessToken));
            Assert.NotNull(result);
        }

        /// <summary>
        /// Integration Test GetPromactTeamMembersDetailsByUserIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactTeamMembersDetailsByUserIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync("df1s5d4fg5sfg51sdf5g1s5d1f5sddfs", _userScopeResponse.AccessToken));
            Assert.NotNull(result);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUserDetailsBySlackGroupNameAsync
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUserDetailsBySlackGroupNameAsync()
        {
            var result = await _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync("Slash-Command", _userScopeResponse.AccessToken);
            Assert.Equal(result.Count, 1);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUserDetailsBySlackGroupNameAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUserDetailsBySlackGroupNameAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(()=>
            _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync("Slash-Command", _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsync()
        {
            var result = await _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync("724f2dd4-49a4-4f6b-8edb-f957f1cbbc23", _userScopeResponse.AccessToken);
            Assert.Equal(result.Count, 2);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsyncUserNotFoundException()
        {
            var result = await Assert.ThrowsAsync<UserNotFoundException>(()=>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync("fs5d1fg5sdf4g5s1df5s1d5f", _userScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.UserNotFoundExceptionMessage);
        }

        /// <summary>
        /// Integration Test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactListOfUsersDetailsByTeamLeaderIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync("fs5d1fg5sdf4g5s1df5s1d5f", _userScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }
        #endregion
    }
}
