using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class VoiceContent
{
    public int CallId { get; set; }

    public int Seq { get; set; }

    public string VoicelogId { get; set; } = null!;

    public string VoiceLogName { get; set; } = null!;

    public string Business { get; set; } = null!;

    public string? SpeakerId { get; set; }

    public string? SpeakerName { get; set; }

    public DateTime StartTime { get; set; }

    public int Length { get; set; }

    public int StartSession { get; set; }

    public int EndSession { get; set; }

    public string SpeakerType { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Entity { get; set; }

    public string? Intention { get; set; }

    public string? Category { get; set; }
}
