namespace Promact.OAuth.Client.DomainModel
{
    /// <summary>
    /// Promact OAuth's Allowed scopes
    /// </summary>
    public enum Scopes
    {
        /// <summary>
        /// Scope email
        /// </summary>
        email,
        /// <summary>
        /// Scope openid
        /// </summary>
        openid,
        /// <summary>
        /// Scope profile
        /// </summary>
        profile,
        /// <summary>
        /// Scope slack user Id
        /// </summary>
        slack_user_id,
        /// <summary>
        /// Scope user read
        /// </summary>
        user_read,
        /// <summary>
        /// Scope project read
        /// </summary>
        project_read,
        /// <summary>
        /// Scope offline_access
        /// </summary>
        offline_access
    }
}
