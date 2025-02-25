using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WiseMediaAcd
{
    public int Logid { get; set; }

    public int Callid { get; set; }

    public int Calltypeid { get; set; }

    public string? Ani { get; set; }

    public string? Dnis { get; set; }

    public string? Contactno { get; set; }

    public string? Summary { get; set; }

    public string? Ivrsdata { get; set; }

    public string? Filepath { get; set; }

    public DateTime ArriveDatetime { get; set; }

    public DateTime? AlertDatetime { get; set; }

    public int AssignAcdgroup { get; set; }

    public int AssignAgent { get; set; }

    public int Priorityid { get; set; }

    public DateTime CreateDatetime { get; set; }

    public DateTime ReadDatetime { get; set; }

    public int ReadFlag { get; set; }
}
