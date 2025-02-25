using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptPool
{
    public int PoolId { get; set; }

    public int TypeId { get; set; }

    public int MaxAgentCnt { get; set; }

    public int CallInbound { get; set; }

    public int CallDialOut { get; set; }

    public int CallOutTalk { get; set; }

    public int CallInter { get; set; }

    public int CallTrans { get; set; }

    public int IdleCnt { get; set; }

    public int ReadyCnt { get; set; }

    public int DialCnt { get; set; }

    public int HoldCnt { get; set; }

    public int OutCnt { get; set; }

    public int PlayCnt { get; set; }

    public int SumLoginTime { get; set; }

    public int SumIdleTime { get; set; }

    public int MaxIdleTime { get; set; }

    public int SumReadyTime { get; set; }

    public int MaxReadyTime { get; set; }

    public int SumDialTime { get; set; }

    public int MaxDialTime { get; set; }

    public int SumTalkInTime { get; set; }

    public int MaxTalkInTime { get; set; }

    public int SumTalkOutTime { get; set; }

    public int MaxTalkOutTime { get; set; }

    public int SumHoldTime { get; set; }

    public int MaxHoldTime { get; set; }

    public int SumWorkTime { get; set; }

    public int MaxWorkTime { get; set; }

    public int SumOutTime { get; set; }

    public int MaxOutTime { get; set; }

    public int SumPlayTime { get; set; }

    public int MaxPlayTime { get; set; }

    public DateTime TimeStamp { get; set; }
}
