using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Sleep_Tracker.Models;

public partial class Night
{
    public int NightId { get; set; }
    public string Date { get; set; }
    public string Day { get; set; }
    public double? TotalBabyHours { get; set; }
}
