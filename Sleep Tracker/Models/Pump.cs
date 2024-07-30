using System;
using System.Collections.Generic;

namespace Sleep_Tracker.Models;

public partial class Pump
{
    public int PumpId { get; set; }

    public string Time { get; set; } = null!;
}
