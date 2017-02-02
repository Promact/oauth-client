namespace Promact.OAuth.Client.DomainModel
{
    /// <summary>
    /// Promact Leave Allowed
    /// </summary>
    public class LeaveAllowed
    {
        /// <summary>
        /// Number of casual leave allowed
        /// </summary>
        public double CasualLeave { get; set; }

        /// <summary>
        /// Number of sick leave allowed
        /// </summary>
        public double SickLeave { get; set; }
    }
}
