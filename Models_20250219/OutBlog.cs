using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class OutBlog
{
    public int? CallId { get; set; }

    public string? CommentOnId { get; set; }

    public string? SenderName { get; set; }

    public string? Message { get; set; }

    public string? Pic { get; set; }

    public string? WatchUrl { get; set; }

    public string? SoundUrl { get; set; }

    public int? State { get; set; }

    public int? CommandType { get; set; }
}
