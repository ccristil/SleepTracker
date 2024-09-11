using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sleep_Tracker.Models;

public partial class DiaperChange
{
    public int DiaperChangeId { get; set; }

    public string Time { get; set; }
    [Required(ErrorMessage = "Change time is a required field.")]
    public bool Poop { get; set; }
    [ForeignKey("Shift")]
    public int ShiftId { get; set; }
}
