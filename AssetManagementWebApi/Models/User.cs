using System;
using System.Collections.Generic;

namespace AssetManagementWebApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Username { get; set; }

    public string PasswordHash { get; set; } = null!;

    public bool IsOnline { get; set; }


    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Hardware> Hardwares { get; set; } = new List<Hardware>();

    public virtual ICollection<Software> Softwares { get; set; } = new List<Software>();
}
