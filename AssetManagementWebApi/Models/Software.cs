using System;
using System.Collections.Generic;

namespace AssetManagementWebApi.Models;

public partial class Software
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Version { get; set; }

    public string? LicenseKey { get; set; }

    public int? AssignedUserId { get; set; }

    public virtual User? AssignedUser { get; set; }
}
