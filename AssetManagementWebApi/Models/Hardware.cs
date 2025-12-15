using System;
using System.Collections.Generic;

namespace AssetManagementWebApi.Models;

public partial class Hardware
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Model { get; set; } = null!;

    public DateOnly? PurchaseDate { get; set; }

    public int? AssignedUserId { get; set; }

    public virtual User? AssignedUser { get; set; }
}
