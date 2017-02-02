using System;
using System.Collections.Generic;

namespace Promact.OAuth.Client.DomainModel
{
    /// <summary>
    /// Promact Project 
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Id of project
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of project
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Slack channel name of project
        /// </summary>
        public string SlackChannelName { get; set; }

        /// <summary>
        /// Indicator or project active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Project team leader's user Id
        /// </summary>
        public string TeamLeaderId { get; set; }

        /// <summary>
        /// Project created by user Id
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Project created on date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// If any update in project then by whom it's updated, user Id
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// If any update in project then by date of update
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Team leader details
        /// </summary>
        public User TeamLeader { get; set; }

        /// <summary>
        /// List of user in project
        /// </summary>
        public List<User> ApplicationUsers { get; set; }
    }
}
