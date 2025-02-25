namespace WisePBX.NET8.Models.Wise
{
    public class SP_wallboard_count_Result
    {
        public Nullable<decimal> service_level { get; set; }    
        public Nullable<decimal> abandoned_rate { get; set; }
        public Nullable<int> income_calls { get; set; }
        public Nullable<int> outbound_calls { get; set; }
    }
}
