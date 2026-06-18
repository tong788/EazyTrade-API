using System;
using System.Collections.Generic;

namespace EazyTrade.Models;

public partial class ImageFile
{
    public int Id { get; set; }

    public string FileUrl { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public long FileSize { get; set; }

    public int CreateBy { get; set; }

    public DateTime CreateAt { get; set; }

    public int UpdateBy { get; set; }

    public DateTime UpdateAt { get; set; }

    public int ReferenceId { get; set; }

    public string MimeType { get; set; } = null!;

    public string ReferenceType { get; set; } = null!;
}
