using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Promact.OAuth.Client.Repository.User;
using Promact.OAuth.Client.Util.StringConstant;
using Xunit;
using Promact.OAuth.Client.DomainModel;
using System.Net;
using Moq;
using Promact.OAuth.Client.Util.HttpClientWrapper;
using System.Security.Authentication;
using System.Net.Http;
using Promact.OAuth.Client.Util.ExceptionHandler;
using Newtonsoft.Json;

namespace Promact.OAuth.Client.Test
{
    public class UserModuleTest : BaseProvider
    {
        #region Private Variable
        private readonly IUserModule _userModule;
        private readonly IStringConstant _stringConstant;
        private readonly Mock<IHttpClientService> _mockHttpClientService;
        User user = new User();
        List<User> userList = new List<User>();
        UserRole userRole = new UserRole();
        List<UserRole> userRoleList = new List<UserRole>();
        LeaveAllowed leaveAllowed = new LeaveAllowed();
        #endregion

        #region Constructor
        public UserModuleTest() : base()
        {
            _userModule = serviceProvider.GetService<IUserModule>();
            _stringConstant = serviceProvider.GetService<IStringConstant>();
            _mockHttpClientService = serviceProvider.GetService<Mock<IHttpClientService>>();
            _userModule.AccessToken = _stringConstant.AccessTokenForTest;
            Initialize();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// To test GetPromactUserDetailByUserIdAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByUserIdAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserDetialBySlackUserIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, SerializationOfUser(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.UserIdForTest);
            Assert.Equal(_stringConstant.UserIdForTest, expectedResult.Id);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserDetailByUserIdAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByUserIdAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserDetialBySlackUserIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserDetailByUserIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByUserIdAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserDetialBySlackUserIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserDetailByUserIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByUserIdAsyncForUserNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserDetialBySlackUserIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserDetailByUserIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByUserIdAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetPromactUserDetailByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetListOfPromactTeamLeaderByUserIdAsync
        /// </summary>
        [Fact]
        public async Task TestGetListOfPromactTeamLeaderByUserIdAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetListOfPromactTeamLeaderByUsersSlackIdUrl, 
                _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, SerializationOfListOfUser(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.UserIdForTest);
            Assert.Equal(true, expectedResult.Any());
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetListOfPromactTeamLeaderByUserIdAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUserIdAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetListOfPromactTeamLeaderByUsersSlackIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetListOfPromactTeamLeaderByUserIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUserIdAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetListOfPromactTeamLeaderByUsersSlackIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetListOfPromactTeamLeaderByUserIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUserIdAsyncForUserNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetListOfPromactTeamLeaderByUsersSlackIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetListOfPromactTeamLeaderByUserIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetListOfPromactTeamLeaderByUserIdAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetListOfPromactTeamLeaderByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetListOfPromactManagementDetailsAsync
        /// </summary>
        [Fact]
        public async Task TestGetListOfPromactManagementDetailsAsync()
        {
            MockingHttpClientService(_stringConstant.GetListOfPromactManagementDetailsUrl, SerializationOfListOfUser(), 
                HttpStatusCode.OK);
            var expectedResult = await _userModule.GetListOfPromactManagementDetailsAsync();
            Assert.Equal(true, expectedResult.Any());
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, 
                _stringConstant.GetListOfPromactManagementDetailsUrl), Times.Once);
        }

        /// <summary>
        /// To test GetListOfPromactManagementDetailsAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetListOfPromactManagementDetailsAsyncForAuthenticationExceptionAsync()
        {
            MockingHttpClientService(_stringConstant.GetListOfPromactManagementDetailsUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetListOfPromactManagementDetailsAsync());
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest,
            _stringConstant.GetListOfPromactManagementDetailsUrl), Times.Once);
        }

        /// <summary>
        /// To test GetListOfPromactManagementDetailsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetListOfPromactManagementDetailsAsyncForHttpRequestExceptionAsync()
        {
            MockingHttpClientService(_stringConstant.GetListOfPromactManagementDetailsUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetListOfPromactManagementDetailsAsync());
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest,
            _stringConstant.GetListOfPromactManagementDetailsUrl), Times.Once);
        }

        /// <summary>
        /// To test GetListOfPromactManagementDetailsAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetListOfPromactManagementDetailsAsyncForUserNotFoundExceptionAsync()
        {
            MockingHttpClientService(_stringConstant.GetListOfPromactManagementDetailsUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetListOfPromactManagementDetailsAsync());
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest,
            _stringConstant.GetListOfPromactManagementDetailsUrl), Times.Once);
        }

        /// <summary>
        /// To test GetListOfPromactManagementDetailsAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetListOfPromactManagementDetailsAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetListOfPromactManagementDetailsAsync());
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetPromactUserLeaveAllowedDetailsAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserLeaveAllowedDetailsAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserLeaveAllowedDetailsUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, SerializationOfLeaveAllowed(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.UserIdForTest);
            Assert.Equal(Convert.ToInt32(_stringConstant.CasualLeaveForTest), expectedResult.CasualLeave);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserLeaveAllowedDetailsAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserLeaveAllowedDetailsAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserLeaveAllowedDetailsUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserLeaveAllowedDetailsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserLeaveAllowedDetailsAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserLeaveAllowedDetailsUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserLeaveAllowedDetailsAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserLeaveAllowedDetailsAsyncForUserNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserLeaveAllowedDetailsUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserLeaveAllowedDetailsAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserLeaveAllowedDetailsAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetPromactUserLeaveAllowedDetailsAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetPromactUserIsAdminOrNotAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserIsAdminOrNotAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserIsAdminOrNotUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, true.ToString().ToLower(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.UserIdForTest);
            Assert.Equal(true, expectedResult);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserIsAdminOrNotAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserIsAdminOrNotAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserIsAdminOrNotUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserIsAdminOrNotAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserIsAdminOrNotAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserIsAdminOrNotUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserIsAdminOrNotAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserIsAdminOrNotAsyncForUserNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserIsAdminOrNotUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserIsAdminOrNotAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserIsAdminOrNotAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetPromactUserIsAdminOrNotAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetPromactUserDetailByIdAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByIdAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserDetailByIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, SerializationOfUser(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetPromactUserDetailByIdAsync(_stringConstant.UserIdForTest);
            Assert.Equal(_stringConstant.EmailRandomValueForTest, expectedResult.Email);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserDetailByIdAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByIdAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserDetailByIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetPromactUserDetailByIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserDetailByIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByIdAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserDetailByIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserDetailByIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserDetailByIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByIdAsyncForUserNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserDetailByIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetPromactUserDetailByIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserDetailByIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserDetailByIdAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetPromactUserDetailByIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetPromactUserRoleAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserRoleAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserRoleUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, SerializationOfListOfUserRole(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetPromactUserRoleAsync(_stringConstant.UserIdForTest);
            Assert.Equal(true, expectedResult.Any());
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserRoleAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserRoleAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserRoleUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetPromactUserRoleAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserRoleAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserRoleAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserRoleUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetPromactUserRoleAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserRoleAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserRoleAsyncForUserNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactUserRoleUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetPromactUserRoleAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactUserRoleAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetPromactUserRoleAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetPromactUserRoleAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetPromactTeamMembersDetailsByUserIdAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactTeamMembersDetailsByUserIdAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactTeamMembersDetailsByUserIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, SerializationOfListOfUserRole(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.UserIdForTest);
            Assert.Equal(true, expectedResult.Any());
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactTeamMembersDetailsByUserIdAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactTeamMembersDetailsByUserIdAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactTeamMembersDetailsByUserIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactTeamMembersDetailsByUserIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactTeamMembersDetailsByUserIdAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactTeamMembersDetailsByUserIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactTeamMembersDetailsByUserIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactTeamMembersDetailsByUserIdAsyncForUserNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactTeamMembersDetailsByUserIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactTeamMembersDetailsByUserIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetPromactTeamMembersDetailsByUserIdAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetPromactTeamMembersDetailsByUserIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetPromactListOfUserDetailsBySlackGroupNameAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUserDetailsBySlackGroupNameAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectUserByGroupNameUrl, _stringConstant.SlackGroupNameForTest);
            MockingHttpClientService(contentUrl, SerializationOfListOfUser(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.SlackGroupNameForTest);
            Assert.Equal(true, expectedResult.Any());
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary> 
        /// To test GetPromactListOfUserDetailsBySlackGroupNameAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUserDetailsBySlackGroupNameAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectUserByGroupNameUrl, _stringConstant.SlackGroupNameForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.SlackGroupNameForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactListOfUserDetailsBySlackGroupNameAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUserDetailsBySlackGroupNameAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectUserByGroupNameUrl, _stringConstant.SlackGroupNameForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.SlackGroupNameForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactListOfUserDetailsBySlackGroupNameAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUserDetailsBySlackGroupNameAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetPromactListOfUserDetailsBySlackGroupNameAsync(_stringConstant.SlackGroupNameForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }

        /// <summary>
        /// To test GetPromactListOfUsersDetailsByTeamLeaderIdAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUsersDetailsByTeamLeaderIdAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactListOfUsersDetailsByTeamLeaderIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, SerializationOfListOfUser(), HttpStatusCode.OK);
            var expectedResult = await _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.UserIdForTest);
            Assert.Equal(true, expectedResult.Any());
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUsersDetailsByTeamLeaderIdAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactListOfUsersDetailsByTeamLeaderIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUsersDetailsByTeamLeaderIdAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactListOfUsersDetailsByTeamLeaderIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for UserNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUsersDetailsByTeamLeaderIdAsyncForUserNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactListOfUsersDetailsByTeamLeaderIdUrl, _stringConstant.UserIdForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<UserNotFoundException>(() =>
            _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.UserIdForTest));
            Assert.Equal(_stringConstant.UserNotFoundExceptionMessage, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactListOfUsersDetailsByTeamLeaderIdAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task TestGetPromactListOfUsersDetailsByTeamLeaderIdAsyncForAccessTokenNullableExceptionAsync()
        {
            _userModule.AccessToken = null;
            var result = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _userModule.GetPromactListOfUsersDetailsByTeamLeaderIdAsync(_stringConstant.SlackGroupNameForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, result.Message);
        }
        #endregion

        #region Mocking
        /// <summary>
        /// Private method to mock http client service and result expected result
        /// </summary>
        /// <param name="contentUrl">content url of request</param>
        /// <param name="expectedResult">expected result from request</param>
        /// <param name="expectedStatus">expected status of request</param>
        private void MockingHttpClientService(string contentUrl, string expectedResult, HttpStatusCode expectedStatus)
        {
            RequestAndReponse requestAndResponse = new RequestAndReponse();
            requestAndResponse.ResponseContent = expectedResult;
            requestAndResponse.Status = expectedStatus;
            var result = Task.FromResult(requestAndResponse);
            _mockHttpClientService.Setup(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl)).Returns(result);
        }
        #endregion

        #region Initialisation
        /// <summary>
        /// Intialization at run time
        /// </summary>
        public void Initialize()
        {
            user.Email = _stringConstant.EmailRandomValueForTest;
            user.Id = _stringConstant.UserIdForTest;
            user.IsActive = true;
            user.NumberOfCasualLeave = 9;
            user.NumberOfSickLeave = 6;
            user.UserName = _stringConstant.EmailRandomValueForTest;
            userList.Add(user);
            userRole.UserName = _stringConstant.EmailRandomValueForTest;
            userRole.UserId = _stringConstant.UserIdForTest;
            userRoleList.Add(userRole);
            leaveAllowed.CasualLeave = 9;
            leaveAllowed.SickLeave = 6;
        }
        #endregion

        #region Serialization
        /// <summary>
        /// Method used to serialize user object in json string
        /// </summary>
        /// <returns>json string of project</returns>
        private string SerializationOfUser()
        {
            return JsonConvert.SerializeObject(user);
        }

        /// <summary>
        /// Method used to serialize list of user in json string
        /// </summary>
        /// <returns>json string of project</returns>
        private string SerializationOfListOfUser()
        {
            return JsonConvert.SerializeObject(userList);
        }

        /// <summary>
        /// Method used to serialize list of userRole in json string
        /// </summary>
        /// <returns>json string of project</returns>
        private string SerializationOfListOfUserRole()
        {
            return JsonConvert.SerializeObject(userRoleList);
        }

        /// <summary>
        /// Method used to serialize leaveAllowed in json string
        /// </summary>
        /// <returns>json string of project</returns>
        private string SerializationOfLeaveAllowed()
        {
            return JsonConvert.SerializeObject(leaveAllowed);
        }
        #endregion
    }
}
