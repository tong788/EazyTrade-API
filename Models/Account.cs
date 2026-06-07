using System;
using System.Collections.Generic;

namespace EazyTrade.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Email { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateAt { get; set; }

    public int UpdateBy { get; set; }

    public DateTime UpdateAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<StoreAccount> StoreAccounts { get; set; } = new List<StoreAccount>();
}
