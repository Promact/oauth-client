using System;

namespace Promact.OAuth.Client.Util.ExceptionHandler
{
    /// <summary>
    /// Project not found exception
    /// </summary>
    public class ProjectNotFoundException : Exception
    {
        /// <summary>
        /// Project not found exception
        /// <param name="errorMessage">Error message to be send with exception</param>
        /// </summary>
        public ProjectNotFoundException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
