namespace Sleep_Tracker.Models;

public interface ISleepTrackerRepository
{
    IQueryable<Night> Nights { get; }
    IQueryable<Shift> Shifts { get; }

    public void AddNight(Night night);
    
    public void AddShift(Shift shift);
}