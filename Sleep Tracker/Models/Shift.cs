using System;
using System.Collections.Generic;

namespace Sleep_Tracker.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string TimeWindow { get; set; } = null!;
}
