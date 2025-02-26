using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.SConnector;

public partial class SC_OnlineForm
{
    public int ticket_id { get; set; }

    public int field_id { get; set; }

    public string? field_key { get; set; }

    public string? field_value { get; set; }
}
