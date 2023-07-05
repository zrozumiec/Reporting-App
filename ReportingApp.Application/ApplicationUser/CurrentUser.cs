namespace ReportingApp.Application.ApplicationUser
{
    /// <summary>
    /// Current user data.
    /// </summary>
    public class CurrentUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentUser"/> class.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="name">User name.</param>
        /// <param name="roles">Collection of user roles.</param>
        public CurrentUser(string id, string name, IEnumerable<string> roles)
        {
            this.Id = id;
            this.Name = name;
            this.Roles = roles;
        }

        /// <summary>
        /// Gets or sets user Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets user roles.
        /// </summary>
        public IEnumerable<string> Roles { get; set; }

        /// <summary>
        /// Checks if user contain specify role.
        /// </summary>
        /// <param name="role">Role name.</param>
        /// <returns>True if user has specify role otherwise false.</returns>
        public bool ContainRole(string role) => this.Roles.Contains(role);
    }
}
