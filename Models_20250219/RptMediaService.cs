using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptMediaService
{
    public int ServiceId { get; set; }

    public int TypeId { get; set; }

    public int MediaEmailInH { get; set; }

    public int MediaEmailInU { get; set; }

    public int MediaEmailOutH { get; set; }

    public int MediaEmailOutU { get; set; }

    public int MediaVmailInH { get; set; }

    public int MediaVmailInU { get; set; }

    public int MediaFaxInH { get; set; }

    public int MediaFaxInU { get; set; }

    public int MediaFaxOutH { get; set; }

    public int MediaFaxOutU { get; set; }

    public int MediaWebcallInH { get; set; }

    public int MediaWebchatInH { get; set; }

    public DateTime TimeStamp { get; set; }

    public int? MediaWebcallInU { get; set; }

    public int? MediaWebchatInU { get; set; }
}
