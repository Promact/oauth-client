using System;

namespace Promact.OAuth.Client.Util.ExceptionHandler
{
    /// <summary>
    /// Exception for Access token null
    /// </summary>
    public class AccessTokenNullableException : Exception
    {
        /// <summary>
        /// Constructor of AccessTokenNullableException
        /// <param name="errorMessage">Error message to be send with exception</param>
        /// </summary>
        public AccessTokenNullableException(string errorMessage) 
            : base(errorMessage)
        {
        }
    }
}
