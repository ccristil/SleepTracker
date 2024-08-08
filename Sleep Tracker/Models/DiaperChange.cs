using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sleep_Tracker.Models;

public partial class DiaperChange
{
    public int DiaperChangeId { get; set; }

    public string Time { get; set; }
    [Required(ErrorMessage = "Change time is a required field.")]
    public int Poop { get; set; }
    public int ShiftId { get; set; }
}
