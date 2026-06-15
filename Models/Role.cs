using System;
using System.Collections.Generic;

namespace EazyTrade.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CreateBy { get; set; }

    public DateTime CreateAt { get; set; }

    public int UpdateBy { get; set; }

    public DateTime UpdateAt { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
