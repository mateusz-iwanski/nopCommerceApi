namespace nopCommerceApi.Models.User
{
    /// <summary>
    /// Roles is DTO type class, are used to determine the level of access a user has to the API.
    /// 
    /// Each user logging into API must be assigned a role.
    /// </summary>
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }

        public RoleDto(string name)
        {
            Name = string.Empty;
        }
    }
}
