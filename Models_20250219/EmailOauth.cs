using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class EmailOauth
{
    public string Campaign { get; set; } = null!;

    public string Emails { get; set; } = null!;

    public string? ClientId { get; set; }

    public string? TenantId { get; set; }

    public string? ClientSecret { get; set; }
}
