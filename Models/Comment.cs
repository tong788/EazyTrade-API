using System;
using System.Collections.Generic;

namespace EazyTrade.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Detail { get; set; }

    public int CommodityId { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateAt { get; set; }

    public int UpdateBy { get; set; }

    public DateTime UpdateAt { get; set; }

    public DateTime? CancelDate { get; set; }

    public virtual Commodity Commodity { get; set; } = null!;
}
