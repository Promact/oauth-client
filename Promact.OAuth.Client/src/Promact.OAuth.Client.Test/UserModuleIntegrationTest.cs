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
            PromactBaseUrl.PromactOAuthUrl = "http://oauth.promactinfo.com/";
        }
        #endregion

        #region Test Cases
        /// <summary>
        /// Integration Test GetPromactUserDetailBySlackUserIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactUserDetailBySlackUserIdAsync()
        {
            var result = await _userModule.GetPromactUserDetailBySlackUserIdAsync("8d29efae-d747-4fc6-a7f1-13f687bd5d67", _userScopeResponse.AccessToken);
            Assert.Equal(result.Email, "admin@promactinfo.com");
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
        //[Fact]
        public async Task GetListOfPromactTeamLeaderByUsersSlackIdAsync()
        {
            var result = await _userModule.GetListOfPromactTeamLeaderByUsersSlackIdAsync("9cdc7982-25b9-45a4-afdc-6b13e6e53ca6", _userScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
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
            Assert.NotEqual(result.Count, 0);
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
            var result = await _userModule.GetPromactUserLeaveAllowedDetailsAsync("d37a7afe-ae39-414d-b9fc-8150629a7f85", _userScopeResponse.AccessToken);
            Assert.Equal(result.CasualLeave, 2);
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
            var result = await _userModule.GetPromactUserIsAdminOrNotAsync("8d29efae-d747-4fc6-a7f1-13f687bd5d67", _userScopeResponse.AccessToken);
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
            var result = await _userModule.GetPromactUserDetailByIdAsync("8d29efae-d747-4fc6-a7f1-13f687bd5d67", _userScopeResponse.AccessToken);
            Assert.Equal(result.Email, "admin@promactinfo.com");
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
            var result = await _userModule.GetPromactUserRoleAsync("8d29efae-d747-4fc6-a7f1-13f687bd5d67", _userScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
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
            var result = await _userModule.GetPromactTeamMembersDetailsByUserIdAsync("8d29efae-d747-4fc6-a7f1-13f687bd5d67", _userScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
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
            var result = await _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync("Slash-Command", _projectScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
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
            var result = await _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync("ea18f1db-6fa5-4050-8930-138e0b1ff21d", _userScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
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
