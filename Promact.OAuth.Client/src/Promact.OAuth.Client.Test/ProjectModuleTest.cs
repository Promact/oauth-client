using Moq;
using Promact.OAuth.Client.DomainModel;
using Promact.OAuth.Client.Repository.Project;
using Promact.OAuth.Client.Util.HttpClientWrapper;
using Promact.OAuth.Client.Util.StringConstant;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using System;
using Promact.OAuth.Client.Util.ExceptionHandler;
using System.Security.Authentication;
using System.Net.Http;

namespace Promact.OAuth.Client.Test
{
    public class ProjectModuleTest : BaseProvider
    {
        #region Private Variable
        private readonly IProjectModule _projectModule;
        private readonly Mock<IHttpClientService> _mockHttpClientService;
        private readonly IStringConstant _stringConstant;
        #endregion

        #region Constructor
        public ProjectModuleTest() : base()
        {
            _projectModule = serviceProvider.GetService<IProjectModule>();
            _stringConstant = serviceProvider.GetService<IStringConstant>();
            _mockHttpClientService = serviceProvider.GetService<Mock<IHttpClientService>>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// To test GetPromactProjectDetailsByGroupNameAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactProjectDetailsByGroupNameAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectDetailsByGroupNameUrl,
                _stringConstant.SlackGroupNameForTest);
            MockingHttpClientService(contentUrl, _stringConstant.GetPromactProjectDetailsByGroupNameAsyncRandomValueForTest,
                HttpStatusCode.OK);
            var expertedResult = await _projectModule.GetPromactProjectDetailsByGroupNameAsync(_stringConstant.SlackGroupNameForTest,
                _stringConstant.AccessTokenForTest);
            Assert.Equal(_stringConstant.RandomProjectNameForTest, expertedResult.Name);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactProjectDetailsByGroupNameAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactProjectDetailsByGroupNameAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectDetailsByGroupNameUrl,
                _stringConstant.SlackGroupNameForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expertedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(()=>
                 _projectModule.GetPromactProjectDetailsByGroupNameAsync(_stringConstant.SlackGroupNameForTest,
                     _stringConstant.AccessTokenForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expertedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactProjectDetailsByGroupNameAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactProjectDetailsByGroupNameAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectDetailsByGroupNameUrl,
                _stringConstant.SlackGroupNameForTest);
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expertedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
                _projectModule.GetPromactProjectDetailsByGroupNameAsync(_stringConstant.SlackGroupNameForTest,
                    _stringConstant.AccessTokenForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expertedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactAllProjectsAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactAllProjectsAsync()
        {
            MockingHttpClientService(_stringConstant.GetPromactAllProjectsUrl,
                _stringConstant.GetPromactAllProjectsAsyncRandomValueForTest, HttpStatusCode.OK);
            var expected = await _projectModule.GetPromactAllProjectsAsync(_stringConstant.AccessTokenForTest);
            Assert.Equal(true, expected.Any());
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest,
                _stringConstant.GetPromactAllProjectsUrl), Times.Once);
        }

        /// <summary>
        ///  To test GetPromactAllProjectsAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactAllProjectsAsyncForAuthenticationExceptionAsync()
        {
            MockingHttpClientService(_stringConstant.GetPromactAllProjectsUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
                _projectModule.GetPromactAllProjectsAsync(_stringConstant.AccessTokenForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest,
                _stringConstant.GetPromactAllProjectsUrl), Times.Once);
        }

        /// <summary>
        ///  To test GetPromactAllProjectsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactAllProjectsAsyncForHttpRequestExceptionAsync()
        {
            MockingHttpClientService(_stringConstant.GetPromactAllProjectsUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
                _projectModule.GetPromactAllProjectsAsync(_stringConstant.AccessTokenForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest,
                _stringConstant.GetPromactAllProjectsUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactAllProjectsAsync for ProjectNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactAllProjectsAsyncForProjectNotFoundExceptionAsync()
        {
            MockingHttpClientService(_stringConstant.GetPromactAllProjectsUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<ProjectNotFoundException>(() =>
                _projectModule.GetPromactAllProjectsAsync(_stringConstant.AccessTokenForTest));
            Assert.Equal(_stringConstant.ProjectNotFoundException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest,
                _stringConstant.GetPromactAllProjectsUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactProjectDetailsByIdAsync
        /// </summary>
        [Fact]
        public async Task TestGetPromactProjectDetailsByIdAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectDetailsByIdUrl,
                Convert.ToInt32(_stringConstant.ProjectIdForTest));
            MockingHttpClientService(contentUrl, _stringConstant.GetPromactProjectDetailsByIdAsyncRandomValueForTest,
                HttpStatusCode.OK);
            var expectedResult = await _projectModule.GetPromactProjectDetailsByIdAsync(Convert.ToInt32(_stringConstant.ProjectIdForTest),
                _stringConstant.AccessTokenForTest);
            Assert.Equal(_stringConstant.UserIdForTest, expectedResult.TeamLeaderId);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactProjectDetailsByIdAsync for AuthenticationException
        /// </summary>
        [Fact]
        public async Task TestGetPromactProjectDetailsByIdAsyncForAuthenticationExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectDetailsByIdUrl,
                Convert.ToInt32(_stringConstant.ProjectIdForTest));
            MockingHttpClientService(contentUrl, null, HttpStatusCode.Forbidden);
            var expectedResult = await Assert.ThrowsAnyAsync<AuthenticationException>(() =>
                _projectModule.GetPromactProjectDetailsByIdAsync(Convert.ToInt32(_stringConstant.ProjectIdForTest),
                    _stringConstant.AccessTokenForTest));
            Assert.Equal(_stringConstant.AccessTokenNotMatchedException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactProjectDetailsByIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task TestGetPromactProjectDetailsByIdAsyncForHttpRequestExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectDetailsByIdUrl,
                Convert.ToInt32(_stringConstant.ProjectIdForTest));
            MockingHttpClientService(contentUrl, null, HttpStatusCode.GatewayTimeout);
            var expectedResult = await Assert.ThrowsAnyAsync<HttpRequestException>(() =>
                _projectModule.GetPromactProjectDetailsByIdAsync(Convert.ToInt32(_stringConstant.ProjectIdForTest),
                    _stringConstant.AccessTokenForTest));
            Assert.Equal(_stringConstant.HttpRequestExceptionErrorMessageForTest, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
        }

        /// <summary>
        /// To test GetPromactProjectDetailsByIdAsync for ProjectNotFoundException
        /// </summary>
        [Fact]
        public async Task TestGetPromactProjectDetailsByIdAsyncForProjectNotFoundExceptionAsync()
        {
            var contentUrl = string.Format(_stringConstant.GetPromactProjectDetailsByIdUrl,
                Convert.ToInt32(_stringConstant.ProjectIdForTest));
            MockingHttpClientService(contentUrl, null, HttpStatusCode.BadRequest);
            var expectedResult = await Assert.ThrowsAnyAsync<ProjectNotFoundException>(() =>
                _projectModule.GetPromactProjectDetailsByIdAsync(Convert.ToInt32(_stringConstant.ProjectIdForTest),
                    _stringConstant.AccessTokenForTest));
            Assert.Equal(_stringConstant.ProjectNotFoundException, expectedResult.Message);
            _mockHttpClientService.Verify(x => x.GetAsync(_stringConstant.AccessTokenForTest, contentUrl), Times.Once);
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
    }
}
