using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.SConnector;

public partial class SC_OfflineForm
{
    public long ticket_id { get; set; }

    public int field_id { get; set; }

    public string? field_name { get; set; }

    public string? field_value { get; set; }

    public int? field_index { get; set; }

    public string? sent_time { get; set; }

    public int? unread { get; set; }
}
