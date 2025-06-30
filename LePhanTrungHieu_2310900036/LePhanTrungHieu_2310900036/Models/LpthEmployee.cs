using System;
using System.Collections.Generic;

namespace LePhanTrungHieu_2310900036.Models;

public partial class LpthEmployee
{
    public int LpthEmpId { get; set; }

    public string? LpthEmpName { get; set; }

    public string? LpthEmpLevel { get; set; }

    public DateOnly? LpthEmpStartDate { get; set; }

    public bool? LpthEmpStatus { get; set; }
}
