using System.Threading.Tasks;
using Promact.OAuth.Client.Repository.Project;
using Microsoft.Extensions.DependencyInjection;
using Promact.OAuth.Client.Util.ExceptionHandler;
using Promact.OAuth.Client.Util.StringConstant;
using Xunit;
using System.Net.Http;
using Promact.OAuth.Client.Repository.BaseUrlSetUp;

namespace Promact.OAuth.Client.Test
{
    public class ProjectModuleIntegrationTest : IntegrationBaseProvider
    {
        private readonly IProjectModule _projectModule;
        private readonly IStringConstant _stringConstant;
        public ProjectModuleIntegrationTest() : base()
        {
            _projectModule = serviceProvider.GetService<IProjectModule>();
            _stringConstant = serviceProvider.GetService<IStringConstant>();
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:35716/";
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByGroupNameAsync
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByGroupNameAsync()
        {
            var result = await _projectModule.GetPromactProjectDetailsByGroupNameAsync("Slash-Command", _projectScopeResponse.AccessToken);
            Assert.Equal(result.Id, 1);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByGroupNameAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByGroupNameAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(()=>
            _projectModule.GetPromactProjectDetailsByGroupNameAsync("Slash-Command", _projectScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactAllProjectsAsync
        /// </summary>
        [Fact]
        public async Task GetPromactAllProjectsAsync()
        {
            var result = await _projectModule.GetPromactAllProjectsAsync(_projectScopeResponse.AccessToken);
            Assert.NotEqual(result.Count, 0);
        }

        /// <summary>
        /// Integration Test GetPromactAllProjectsAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactAllProjectsAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(()=>
            _projectModule.GetPromactAllProjectsAsync(_projectScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByIdAsync
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByIdAsync()
        {
            var result = await _projectModule.GetPromactProjectDetailsByIdAsync(1, _projectScopeResponse.AccessToken);
            Assert.Equal(result.IsActive, true);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByIdAsync for ProjectNotFoundException
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByIdAsyncProjectNotFoundException()
        {
            var result = await Assert.ThrowsAsync<ProjectNotFoundException>(()=>
            _projectModule.GetPromactProjectDetailsByIdAsync(1000, _projectScopeResponse.AccessToken));
            Assert.Equal(result.Message, _stringConstant.ProjectNotFoundException);
        }

        /// <summary>
        /// Integration Test GetPromactProjectDetailsByIdAsync for HttpRequestException
        /// </summary>
        [Fact]
        public async Task GetPromactProjectDetailsByIdAsyncHttpRequestException()
        {
            PromactBaseUrl.PromactOAuthUrl = "http://localhost:1234/";
            var result = await Assert.ThrowsAsync<HttpRequestException>(() =>
            _projectModule.GetPromactProjectDetailsByIdAsync(1000, _projectScopeResponse.AccessToken));
            Assert.NotNull(result.Message);
        }
    }
}
