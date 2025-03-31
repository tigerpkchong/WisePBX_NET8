namespace WisePBX.NET8
{
    public class ACDGroupAccessClass
    {
        public int groupId { get; set; }
        public bool accessible { get; set; }
    }
    public static class WiseResult
    {
        public static readonly string Success = "success";
        public static readonly string Fail = "fail";
        public static readonly string Error = "error";
    }

    public static class WiseError
    {
        public static readonly string InvalidParameters = "Invalid Parameters.";
        public static readonly string NoSuchAgent = "No such agent.";
        public static readonly string NoSuchRecord = "No such record.";
    }
}
