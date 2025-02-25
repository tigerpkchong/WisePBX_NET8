using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class DocumentForm
{
    public int ItemId { get; set; }

    public string DocumentName { get; set; } = null!;

    public string DocumentPath { get; set; } = null!;
}
