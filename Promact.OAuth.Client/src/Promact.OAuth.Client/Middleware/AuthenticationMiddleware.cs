using Promact.OAuth.Client.Util.StringConstant;
using Promact.OAuth.Client.DomainModel;
using Promact.OAuth.Client.Repository.BaseUrlSetUp;
#if NET461
using Owin;
using Microsoft.Owin.Security.OpenIdConnect;
#else
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
#endif

namespace Promact.OAuth.Client.Middleware
{
    /// <summary>
    /// Promact Authentication Middleware
    /// </summary>
    public static class AuthenticationMiddleware
    {
#if NET461 
        /// <summary>
        /// Adds the Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationMiddleware
        /// into the OWIN runtime for promact-oauth-server
        /// </summary>
        /// <param name="app">Owin.IAppBuilder</param>
        /// <param name="options">Configuration Option PromactAuthentication</param>
        /// <returns>Then updated Owin.IAppBuilder</returns>
        public static IAppBuilder UsePromactAuthentication(this IAppBuilder app, PromactAuthenticationOptions options)
        {
            var allowedScopes = string.Join(" ", options.AllowedScopes);
            IStringConstant _stringConstant = new StringConstant();
            var openIdConnectAuthenticationOptions = new OpenIdConnectAuthenticationOptions();
            openIdConnectAuthenticationOptions.Authority = options.Authority;
            openIdConnectAuthenticationOptions.ClientId = options.ClientId;
            openIdConnectAuthenticationOptions.ClientSecret = options.ClientSecret;
            openIdConnectAuthenticationOptions.RedirectUri = options.RedirectUrl;
            openIdConnectAuthenticationOptions.ResponseType = _stringConstant.ResponseTypeCodeAndIdToken;
            openIdConnectAuthenticationOptions.Scope = allowedScopes;
            openIdConnectAuthenticationOptions.SignInAsAuthenticationType = _stringConstant.SignInSchemeCookies;
            openIdConnectAuthenticationOptions.AuthenticationType = _stringConstant.OIDCAuthenticationScheme;
            openIdConnectAuthenticationOptions.PostLogoutRedirectUri = options.LogoutUrl;
            openIdConnectAuthenticationOptions.Notifications = options.Notifications;
            PromactBaseUrl.PromactOAuthUrl = options.Authority;
            return app.UseOpenIdConnectAuthentication(openIdConnectAuthenticationOptions);
        }
#else
        /// <summary>
        /// Adds the Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware
        /// middleware to the specified Microsoft.AspNetCore.Builder.IApplicationBuilder,
        /// which enables OpenID Connect authentication capabilities from promact-oauth-server.
        /// </summary>
        /// <param name="app">Microsoft.AspNetCore.Builder.IApplicationBuilder</param>
        /// <param name="options">Configuration Option PromactAuthentication</param>
        /// <returns>The updated Microsoft.AspNetCore.Builder.IApplicationBuilder</returns>
        public static IApplicationBuilder UsePromactAuthentication(this IApplicationBuilder app, PromactAuthenticationOptions options)
        {
            var openIdConnecOptions = new OpenIdConnectOptions();
            IStringConstant _stringConstant = new StringConstant();
            foreach (var scope in options.AllowedScopes)
            {
                openIdConnecOptions.Scope.Add(scope.ToString());
            }
            openIdConnecOptions.Events = options.Event;
            openIdConnecOptions.AuthenticationScheme = _stringConstant.OIDCAuthenticationScheme;
            openIdConnecOptions.SignInScheme = _stringConstant.SignInSchemeCookies;
            openIdConnecOptions.Authority = options.Authority;
            openIdConnecOptions.RequireHttpsMetadata = options.RequireHttpsMetadata;
            openIdConnecOptions.ClientId = options.ClientId;
            openIdConnecOptions.ClientSecret = options.ClientSecret;
            openIdConnecOptions.ResponseType = _stringConstant.ResponseTypeCodeAndIdToken;
            openIdConnecOptions.PostLogoutRedirectUri = options.LogoutUrl;
            openIdConnecOptions.GetClaimsFromUserInfoEndpoint = true;
            openIdConnecOptions.SaveTokens = true;
            PromactBaseUrl.PromactOAuthUrl = options.Authority;
            return app.UseOpenIdConnectAuthentication(openIdConnecOptions);
        }
#endif
    }
}
