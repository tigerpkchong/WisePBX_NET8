﻿namespace WisePBX.NET8.Models.SConnector
{
    public class get_fb_comment_Result
    {
        public long ticket_id { get; set; }
        public string msg_id { get; set; }
        public string sent_time { get; set; }
        public int index_no { get; set; }
        public string msg_type { get; set; }
        public string msg_content { get; set; }
        public Nullable<int> send_by_flag { get; set; }
        public string msg_object_path { get; set; }
        public string sender { get; set; }
        public string fb_comment_id { get; set; }
        public string sc_post_id { get; set; }
        public string sc_comment_id { get; set; }
        public string complete_date { get; set; }
        public Nullable<int> msg_completed { get; set; }
        public string profile_pic { get; set; }
        public string nick_name { get; set; }
        public string msg_object_client_name { get; set; }
        public string ticket_chat_id { get; set; }
        public string enduser_id { get; set; }
        public Nullable<int> reply_count { get; set; }
    }
}
