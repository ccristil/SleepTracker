using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sleep_Tracker.Models;

public partial class Pump
{
    public int PumpId { get; set; }

    public string Time { get; set; }
    [Required(ErrorMessage = "Pump time is a required field.")]
    public int ShiftId { get; set; }
}
