namespace nopCommerceApi.Models.User
{
    /// <summary>
    /// Used to store the access level for logged in users
    /// </summary>
    public enum Roles
    {
        Admin,  // Admin has full access to the API
        User,  // User has limited access to the API
        Viewer // Viewer has read-only access to the API
    }
}
