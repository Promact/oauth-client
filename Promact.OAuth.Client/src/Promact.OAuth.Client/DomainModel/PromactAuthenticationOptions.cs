#if NET461
using Microsoft.Owin.Security.OpenIdConnect;
#endif
using System.Collections.Generic;

namespace Promact.OAuth.Client.DomainModel
{
    /// <summary>
    /// Configuration Option PromactAuthentication
    /// </summary>
    public class PromactAuthenticationOptions
    {
        /// <summary>
        /// Constuctor of PromactAuthenticationOptions
        /// </summary>
        public PromactAuthenticationOptions()
        {
            AllowedScopes = new List<Scopes>();
        }
        /// <summary>
        /// Promact-Oauth's Client Id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// Promact-Oauth's Client Secret
        /// </summary>
        public string ClientSecret { get; set; }
        /// <summary>
        /// Promact-Oauth's Authority Url
        /// </summary>
        public string Authority { get; set; }
        /// <summary>
        /// Promact-Oauth's Logout Url
        /// </summary>
        public string LogoutUrl { get; set; }
        /// <summary>
        /// Allowed scope for Promact-Oauth's App
        /// </summary>
        public List<Scopes> AllowedScopes { get; }
#if NET461
        /// <summary>
        /// Redirect Url for Promact-Oauth's App
        /// </summary>
        public string RedirectUrl { get; set; }
        /// <summary>
        /// Gets or sets the Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationNotifications
        /// to notify when processing OpenIdConnect messages.
        /// </summary>
        public OpenIdConnectAuthenticationNotifications Notifications { get; set; }
#endif
    }
}
