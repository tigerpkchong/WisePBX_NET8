using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class BlogInfo
{
    public int? CallId { get; set; }

    public string? AccName { get; set; }

    public string? BlogId { get; set; }

    public int? NetType { get; set; }

    public int? BlogType { get; set; }

    public int? CommentNum { get; set; }

    public int? RequestNum { get; set; }

    public string? FileName { get; set; }
}
