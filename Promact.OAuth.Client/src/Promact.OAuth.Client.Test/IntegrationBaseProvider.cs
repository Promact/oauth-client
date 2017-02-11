using System;
using Microsoft.Extensions.DependencyInjection;
using Promact.OAuth.Client.Repository.Project;
using Promact.OAuth.Client.Repository.User;
using Promact.OAuth.Client.Util.StringConstant;
using Promact.OAuth.Client.Util.HttpClientWrapper;
using IdentityModel.Client;
using Promact.OAuth.Client.DomainModel;

namespace Promact.OAuth.Client.Test
{
    public class IntegrationBaseProvider
    {
        #region Variables
        public IServiceProvider serviceProvider { get; set; }
        private readonly TokenClient _client;
        public readonly TokenResponse _userScopeResponse;
        public readonly TokenResponse _projectScopeResponse;
        public readonly DiscoveryResponse _discoveryClient;
        public readonly IStringConstant _stringConstant;
        #endregion

        #region Constructor
        public IntegrationBaseProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<IProjectModule, ProjectModule>();
            services.AddScoped<IUserModule, UserModule>();
            services.AddScoped<IStringConstant, StringConstant>();
            services.AddScoped<IHttpClientService, HttpClientService>();
            serviceProvider = services.BuildServiceProvider();
            _stringConstant = serviceProvider.GetService<IStringConstant>();
            var discovery = new DiscoveryClient(_stringConstant.PromactOAuthUrl);
            discovery.Policy.RequireHttps = false;
            _discoveryClient = discovery.GetAsync().Result;
            _client = new TokenClient(_discoveryClient.TokenEndpoint, _stringConstant.PromactOAuthClientId, 
                _stringConstant.PromactOAuthClientSecret);
            _userScopeResponse = _client.RequestClientCredentialsAsync(Scopes.user_read.ToString()).Result;
            _projectScopeResponse = _client.RequestClientCredentialsAsync(Scopes.project_read.ToString()).Result;
        }
        #endregion
    }
}
