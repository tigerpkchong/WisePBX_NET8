using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.SConnector;

public partial class SC_MsgHistory
{
    public long ticket_id { get; set; }

    public string msg_id { get; set; } = null!;

    public string sent_time { get; set; } = null!;

    public int index_no { get; set; }

    public string? msg_type { get; set; }

    public string? msg_content { get; set; }

    public int? send_by_flag { get; set; }

    public string? msg_object_path { get; set; }

    public string? sender { get; set; }

    public string? fb_comment_id { get; set; }

    public string? sc_post_id { get; set; }

    public string? sc_comment_id { get; set; }

    public string? complete_date { get; set; }

    public int? msg_completed { get; set; }

    public string? profile_pic { get; set; }

    public string? nick_name { get; set; }

    public string? msg_object_client_name { get; set; }

    public string? ticket_chat_id { get; set; }

    public string? enduser_id { get; set; }
}
