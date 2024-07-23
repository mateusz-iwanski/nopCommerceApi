using Castle.Core.Resource;
using nopCommerceApi.Entities.NotUsable;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Security.Policy;

namespace nopCommerceApi.Entities.Usable;

/// <summary>
/// Access Control List (ACL) restricts or grants users access to certain areas of the site. This list is managed by administrators.
/// 
/// The user must have administrator rights to be able to access it. The access list has the following characteristics:
/// - Access control list is role-based, that is, manages roles, such as Global administrators, Content managers, and others. This list of roles can be managed on the Customers → Customer roles page. For further details, refer to Customer roles.
/// - Access control list appears in the administration area. Make sure a user has to be an administrator in order to access the ACL.
/// - There are some predefined administrator actions. These include Manage orders, Manage customers, and much more.
/// 
/// To manage the access control list, go to Configuration → Access control list. The Access control list window will be displayed.
/// </summary>
public partial class AclRecord
{
    /// <summary>
    /// Gets or sets the entity identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the entity name
    /// </summary>
    public string EntityName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the customer role identifier
    /// </summary>
    public int CustomerRoleId { get; set; }

    /// <summary>
    /// Gets or sets the entity identifier
    /// </summary>
    public int EntityId { get; set; }

    public virtual CustomerRole CustomerRole { get; set; } = null!;
}
