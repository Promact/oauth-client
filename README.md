# Promact-OAuth-Client

[![Build Status](https://travis-ci.org/Promact/oauth-client.svg?branch=master)](https://travis-ci.org/Promact/oauth-client)

Client library for Promact OAuth server

# .NET Client for Promact API

This library allows you to interact with Promact OAuth Server endpoints in your .NET applications.
It is fully asynchronous, designed to be non-blocking and object-oriented way to interact with Promact OAuth Server programmatically.

# Installation
You can add this library to your project using Nuget.This is the only method this library is currently distributed unless you choose to build your own binaries using source code. Run the following command in the “Package Manager Console”:
```powershell
Install-Package OAuth.Client.Promact
```
Or right click to your project in Visual Studio, choose “Manage NuGet Packages” and search for **‘OAuth.Client.Promact’** and click ‘Install’.
# Usage

Initialize the middleware

*Startup.cs*
```csharp
using Promact.OAuth.Client.Middleware;

namespace App
{
    class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UsePromactAuthentication
            (
                new PromactAuthenticationOptions()
                {
                    Authority = "http://www.example.com/",
                    ClientId = "HJXF74EQ497GRAL",
                    ClientSecret = "ChcBmvtaUwphIsbmRkbL9amOh9Qy6Q",
                    LogoutUrl = "http://www.examples.com/",
                    AllowedScopes =
                    {
                        Scopes.offline_access,
                        Scopes.email,
                        Scopes.profile,
                        Scopes.openid,
                        Scopes.project_read,
                        Scopes.user_read,
                    }
                    ,
                    Event = new OpenIdConnectEvents()
                    {
                        OnRemoteFailure = token =>
                        {
                            var userClaims = token.HttpContext.User.Claims;
                            return Task.FromResult(0);
                        }
                    }
                });
        }
    }
}
```

Initialize the client:

```csharp
using Promact.OAuth.Client.Repository.User;
using Promact.OAuth.Client.Repository.Project;
using Promact.OAuth.Client.Util.HttpClientWrapper;
using Promact.OAuth.Client.Util.StringConstant;

namespace App
{
    public class Something
    {
        public async Task Default()
        {
            // initialization
            IStringConstant _stringConstant = new StringConstant();
            IHttpClientService _httpClientService = new HttpClientService(_stringConstant);
            IUserModule _user = new UserModule(httpClientService, stringConstant);
            _user.AccessToken = "USER_PROMACT_OAUTH_SERVER_ACCESSTOKEN";
            var userDetails = await _user.GetPromactUserDetailByUserIdAsync("string_user_id");
            var projectDetails = await _project.GetPromactProjectDetailsByIdAsync(INTEGER_PROJECT_ID);
        }
    }
}
```

# Error Handling
Here are typical exceptions thrown from the client library:
* AccessTokenNullableException - When access token will be null and application request and API call
* UserNotFoundException - When application call an API of user details and its not found in OAuth Server
* ProjectNotFoundException - When application call an API of project details and its not found in OAuth Server
* HttpRequestException - When OAuth Server is closed.
* AuthenticationException - When access token is not Authorize to trespass the OAuth Server Authorization policy

# Versioning
Version if this package uses SemVer format: MAJOR.MINOR.PATCH. MINOR segment indicates the OAuth.Promact.Client version support.
