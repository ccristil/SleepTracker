using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sleep_Tracker.Models;

public partial class Shift
{
    public int ShiftId { get; set; }
    [Required(ErrorMessage = "Time window is a required field.")]
    public string TimeWindow { get; set; }
    [Required(ErrorMessage = "Parent is a required field.")]
    public string Parent { get; set; }
    
    public int? NightId { get; set; }
    public double? BabyHours { get; set; }
}
