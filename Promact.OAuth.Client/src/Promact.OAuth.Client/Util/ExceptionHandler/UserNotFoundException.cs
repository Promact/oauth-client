﻿using System;

namespace Promact.OAuth.Client.Util.ExceptionHandler
{
    /// <summary>
    /// User not found exception
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// User not found exception
        /// <param name="errorMessage">Error message to be send with exception</param>
        /// </summary>
        public UserNotFoundException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
