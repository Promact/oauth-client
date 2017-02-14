using System.Threading.Tasks;
using Promact.OAuth.Client.Repository.Project;
using Microsoft.Extensions.DependencyInjection;
using Promact.OAuth.Client.Util.ExceptionHandler;
using Xunit;
using System.Net.Http;
using Promact.OAuth.Client.Repository.BaseUrlSetUp;

namespace Promact.OAuth.Client.Test
{
    public class ProjectModuleIntegrationTest : IntegrationBaseProvider
    {
        #region Private Variables
        private readonly IProjectModule _projectModule;
        #endregion

        #region Constructor
        public ProjectModuleIntegrationTest() : base()
        {
            _projectModule = serviceProvider.GetService<IProjectModule>();
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.PromactOAuthUrl;
            _projectModule.AccessToken = _projectScopeResponse.AccessToken;
        }
        #endregion

        #region Test cases
        /// <summary>
        /// Integration Test GetPromactProjectDetailsByGroupNameAsync
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByGroupNameAsync()
        {
            var result = await _projectModule.GetPromactProjectDetailsByGroupNameAsync(_stringConstant.ProjectGroupNameForTest);
            Assert.Equal(result.Id, 1);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByGroupNameAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByGroupNameAsyncHttpRequestExceptionAsync()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(()=>
            _projectModule.GetPromactProjectDetailsByGroupNameAsync(_stringConstant.ProjectGroupNameForTest));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByGroupNameAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByGroupNameAsyncAccessTokenNullableExceptionAsync()
        {
            _projectModule.AccessToken = null;
            var expertedResult = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _projectModule.GetPromactProjectDetailsByGroupNameAsync(_stringConstant.SlackGroupNameForTest));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, expertedResult.Message);
        }

        /// <summary>
        /// Integration Test GetPromactAllProjectsAsync
        /// </summary>
        [Fact]
        public async Task GetPromactAllProjectsAsync()
        {
            var result = await _projectModule.GetPromactAllProjectsAsync();
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactAllProjectsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactAllProjectsAsyncHttpRequestExceptionAsync()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(()=>
            _projectModule.GetPromactAllProjectsAsync());
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactAllProjectsAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactAllProjectsAsyncAccessTokenNullableExceptionAsync()
        {
            _projectModule.AccessToken = null;
            var expertedResult = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _projectModule.GetPromactAllProjectsAsync());
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, expertedResult.Message);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByIdAsync()
        {
            var result = await _projectModule.GetPromactProjectDetailsByIdAsync(1);
            Assert.Equal(result.IsActive, true);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByIdAsync for ProjectNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByIdAsyncProjectNotFoundExceptionAsync()
        {
            var result = await Assert.ThrowsAsync<ProjectNotFoundException>(()=>
            _projectModule.GetPromactProjectDetailsByIdAsync(0));
            Assert.Equal(result.Message, _stringConstant.ProjectNotFoundException);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByIdAsyncHttpRequestExceptionAsync()
        {
            PromactBaseUrl.PromactOAuthUrl = _stringConstant.RandomUrlForTest;
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _projectModule.GetPromactProjectDetailsByIdAsync(1000));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactAllProjectsAsync for AccessTokenNullableException
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByIdAsyncAccessTokenNullableExceptionAsync()
        {
            _projectModule.AccessToken = null;
            var expertedResult = await Assert.ThrowsAnyAsync<AccessTokenNullableException>(() =>
                _projectModule.GetPromactProjectDetailsByIdAsync(1));
            Assert.Equal(_stringConstant.AccessTokenNullableExceptionMessage, expertedResult.Message);
        }
        #endregion
    }
}
