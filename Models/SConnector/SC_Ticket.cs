using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.SConnector;

public partial class SC_Ticket
{
    public long ticket_id { get; set; }

    public string? enduser_id { get; set; }

    public string? assign_to { get; set; }

    public string? profile_pic { get; set; }

    public string? nick_name { get; set; }

    public string? entry { get; set; }

    public string? last_active_time { get; set; }

    public int? unread_num { get; set; }

    public int? category_id { get; set; }

    public string? category_name { get; set; }

    public string? company_code { get; set; }

    public string? cs_member { get; set; }

    public string? start_time { get; set; }

    public int? status_id { get; set; }

    public decimal? rating { get; set; }

    public int? online_form { get; set; }

    public int? offline_form { get; set; }
}
