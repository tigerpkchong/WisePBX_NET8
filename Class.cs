namespace WisePBX.NET8
{
    public class AcdGroupAccessClass
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
    public static class WiseFunc
    {
        public static class Config
        {
            public static readonly string GetServiceList = "GetServiceList";
            public static readonly string GetACDGroupList = "GetACDGroupList";
            public static readonly string GetAgentList = "GetAgentList";
            public static readonly string GetSupervisorList = "GetSupervisorList";
            public static readonly string GetAgentInfo = "GetAgentInfo";
            public static readonly string GetMonitorStatistics = "GetMonitorStatistics";
            public static readonly string GetACDGroupAccessList = "GetACDGroupAccessList";
            public static readonly string UpdateACDGroupAccessList = "UpdateACDGroupAccessList";
            public static readonly string AddACDGroupAccess = "AddACDGroupAccess";
            public static readonly string DelACDGroupAccess = "DelACDGroupAccess";
            public static readonly string GetDashboardData = "GetDashboardData";
            public static readonly string GetDashboardData_Agent = "GetDashboardData_Agent";
            public static readonly string GetWallboardCount = "GetWallboardCount";

        }
        public static class Email
        {
            public static readonly string GetList = "GetList";
            public static readonly string GetCount = "GetCount";
            public static readonly string GetContent = "GetContent";
            public static readonly string SetHandled = "SetHandled";
            public static readonly string AssignAgent = "AssignAgent";
            public static readonly string UploadContent = "UploadContent";
            public static readonly string RemoveContent = "RemoveContent";
            public static readonly string GetSetting = "GetSetting";
            public static readonly string AddSetting = "AddSetting";
            public static readonly string DelSetting = "DelSetting";
            public static readonly string GetJunkMails = "GetJunkMails";
        }
}
