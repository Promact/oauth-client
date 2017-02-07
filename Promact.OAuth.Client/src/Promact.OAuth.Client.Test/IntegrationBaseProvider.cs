using System;
using Microsoft.Extensions.DependencyInjection;
using Promact.OAuth.Client.Repository.Project;
using Promact.OAuth.Client.Repository.User;
using Promact.OAuth.Client.Util.StringConstant;
using Promact.OAuth.Client.Util.HttpClientWrapper;
using IdentityModel.Client;

namespace Promact.OAuth.Client.Test
{
    public class IntegrationBaseProvider
    {
        public IServiceProvider serviceProvider { get; set; }
        private readonly DiscoveryResponse _discovery;
        private readonly TokenClient _client;
        public readonly TokenResponse _userScopeResponse;
        public readonly TokenResponse _projectScopeResponse;

        public IntegrationBaseProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<IProjectModule, ProjectModule>();
            services.AddScoped<IUserModule, UserModule>();
            services.AddScoped<IStringConstant, StringConstant>();
            services.AddScoped<IHttpClientService, HttpClientService>();
            serviceProvider = services.BuildServiceProvider();
            _discovery = DiscoveryClient.GetAsync("http://localhost:35716/").Result;
            _client = new TokenClient(_discovery.TokenEndpoint, "O1UGSJW6X4V16IY", "RtZIZVt7VyW11NiSKazAxvTZlOpjRf");
            _userScopeResponse = _client.RequestClientCredentialsAsync("user_read").Result;
            _projectScopeResponse = _client.RequestClientCredentialsAsync("project_read").Result;
        }
    }
}
