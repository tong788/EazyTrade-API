using System;
using System.Collections.Generic;

namespace EazyTrade.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AccountId { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateAt { get; set; }

    public int UpdateBy { get; set; }

    public DateTime UpdateAt { get; set; }

    public virtual ICollection<StoreAccount> StoreAccounts { get; set; } = new List<StoreAccount>();
}
