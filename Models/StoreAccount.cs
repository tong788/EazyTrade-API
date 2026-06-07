using System;
using System.Collections.Generic;

namespace EazyTrade.Models;

public partial class StoreAccount
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int StoreId { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateAt { get; set; }

    public int UpdateBy { get; set; }

    public DateTime UpdateAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
