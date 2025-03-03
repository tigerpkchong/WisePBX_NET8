namespace WisePBX.NET8.Models.Wise_SP
{
    public class SP_Dashboard_Data_Result
    {
        public DateTime time_stamp { get; set; }
        public int? inbound_call { get; set; }
        public int? inbound_vm { get; set; }
        public int? inbound_email { get; set; }
        public int? inbound_fax { get; set; }
        public int? inbound_webchat { get; set; }
        public int? inbound_wechat { get; set; }
        public int? inbound_fb_msg { get; set; }
        public int? inbound_whatsapp { get; set; }
        public int? outbound_call { get; set; }
        public int? outbound_sms { get; set; }
        public int? outbound_email { get; set; }
        public int? outbound_fax { get; set; }
    }
}
