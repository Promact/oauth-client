namespace Promact.OAuth.Client.Repository.BaseUrlSetUp
{
    /// <summary>
    /// Promact OAuth base url static class
    /// </summary>
    public static class PromactBaseUrl
    {
        /// <summary>
        /// Promact OAuth's static base url
        /// </summary>
        private static string _promactBaseUrl;

        /// <summary>
        /// Promact OAuth's static base url
        /// </summary>
        public static string PromactOAuthUrl
        {
            get
            {
                return _promactBaseUrl;
            }
            set
            {
                _promactBaseUrl = value;
            }
        }
    }
}
