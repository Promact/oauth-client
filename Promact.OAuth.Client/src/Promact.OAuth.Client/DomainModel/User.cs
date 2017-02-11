namespace Promact.OAuth.Client.DomainModel
{
    /// <summary>
    /// Promact User
    /// </summary>
    public class User
    {
        /// <summary>
        /// User's Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User is active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Role of user
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// User's Email Id 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User's username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Number of casual leave allowed to user
        /// </summary>
        public double NumberOfCasualLeave { get; set; }

        /// <summary>
        /// Number of sick leave allowed to user
        /// </summary>
        public double NumberOfSickLeave { get; set; }

        /// <summary>
        /// User's unique name
        /// </summary>
        public string UniqueName { get { return FirstName + "-" + Email; } }
    }
}
