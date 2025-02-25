using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models
{
    public class SP_Dashboard_Data_Agent_Result
    {
        public int agent_id { get; set; }
        public Nullable<int> inbound_call { get; set; }
        public Nullable<int> inbound_vm { get; set; }
        public Nullable<int> inbound_email { get; set; }
        public Nullable<int> inbound_fax { get; set; }
        public Nullable<int> inbound_webchat { get; set; }
        public Nullable<int> inbound_wechat { get; set; }
        public Nullable<int> inbound_fb_msg { get; set; }
        public Nullable<int> inbound_whatsapp { get; set; }
        public Nullable<int> outbound_call { get; set; }
        public Nullable<int> outbound_sms { get; set; }
        public Nullable<int> outbound_email { get; set; }
        public Nullable<int> outbound_fax { get; set; }
    }
}
