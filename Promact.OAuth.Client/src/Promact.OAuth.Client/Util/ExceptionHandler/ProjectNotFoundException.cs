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
        /// </summary>
        public ProjectNotFoundException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
