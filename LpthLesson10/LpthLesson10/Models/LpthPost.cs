using System;
using System.Collections.Generic;

namespace LpthLesson10.Models;

public partial class LpthPost
{
    public int LpthId { get; set; }

    public string? LpthTitle { get; set; }

    public string? LpthImage { get; set; }

    public string? LpthContent { get; set; }

    public bool? LpthStatus { get; set; }
}
