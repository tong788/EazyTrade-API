using System;
using System.Collections.Generic;

namespace EazyTrade.Models;

public partial class Commodity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? PublishDate { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateAt { get; set; }

    public int UpdateBy { get; set; }

    public DateTime UpdateAt { get; set; }

    public DateTime? CancelDate { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
