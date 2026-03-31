namespace WisePBX.NET8.Models.Wise_SP
{
    public class SP_wallboard_count_Result
    {
        public decimal? service_level { get; set; }
        public decimal? abandoned_rate { get; set; }
        public int? income_calls { get; set; }
        public int? answered_call { get; set; }
        public int? abandoned_call { get; set; }
        public int? outbound_calls { get; set; }
        public int? inbound_email { get; set; }
        public int? outbound_email { get; set; }
        public int? outbound_emailInternal { get; set; }
    }
}
