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
        private readonly TokenClient _client;
        public readonly TokenResponse _userScopeResponse;
        public readonly TokenResponse _projectScopeResponse;
        public readonly DiscoveryResponse _discoveryClient;

        public IntegrationBaseProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<IProjectModule, ProjectModule>();
            services.AddScoped<IUserModule, UserModule>();
            services.AddScoped<IStringConstant, StringConstant>();
            services.AddScoped<IHttpClientService, HttpClientService>();
            serviceProvider = services.BuildServiceProvider();
            var discovery = new DiscoveryClient("http://oauth.promactinfo.com/");
            discovery.Policy.RequireHttps = false;
            _discoveryClient = discovery.GetAsync().Result;
            _client = new TokenClient(_discoveryClient.TokenEndpoint, "OOKK4SVDYQ8XRUU", "icbbHra92LEzIS5AHE6NuuR0Qk20Oo");
            _userScopeResponse = _client.RequestClientCredentialsAsync("user_read").Result;
            _projectScopeResponse = _client.RequestClientCredentialsAsync("project_read").Result;
        }
    }
}
