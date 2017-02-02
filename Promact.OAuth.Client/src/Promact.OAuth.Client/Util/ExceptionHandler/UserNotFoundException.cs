using System;

namespace Promact.OAuth.Client.Util.ExceptionHandler
{
    /// <summary>
    /// User not found exception
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// User not found exception
        /// </summary>
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}
