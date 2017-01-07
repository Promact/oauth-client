using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Promact.OAuth.Client.Repository.Project;
using Promact.OAuth.Client.Repository.User;
using Promact.OAuth.Client.Util.StringConstant;
using Promact.OAuth.Client.Util.HttpClientWrapper;
using Moq;

namespace Promact.OAuth.Client.Test
{
    public class BaseProvider
    {
        public IServiceProvider serviceProvider { get; set; }

        public BaseProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<IProjectModule, ProjectModule>();
            services.AddScoped<IUserModule, UserModule>();
            services.AddScoped<IStringConstant, StringConstant>();
            var httpClientMock = new Mock<IHttpClientService>();
            var httpClientMockObject = httpClientMock.Object;
            services.AddScoped(x => httpClientMock);
            services.AddScoped(x => httpClientMockObject);
            serviceProvider = services.BuildServiceProvider();
        }
    }
}
