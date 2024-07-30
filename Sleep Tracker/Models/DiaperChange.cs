using System;
using System.Collections.Generic;

namespace Sleep_Tracker.Models;

public partial class DiaperChange
{
    public int DiaperChangeId { get; set; }

    public string Time { get; set; } = null!;

    public int Poop { get; set; }
}
