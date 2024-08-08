namespace Sleep_Tracker.Models;

public class EFSleepTrackerRepository : ISleepTrackerRepository
{
    private SleepTrackerContext _context;

    public EFSleepTrackerRepository(SleepTrackerContext temp)
    {
        _context = temp;
    }

    public IQueryable<Night> Nights => _context.Nights;
    public IQueryable<Shift> Shifts => _context.Shifts;

    public void AddNight(Night night)
    {
        _context.Nights.Add(night);
        _context.SaveChanges();
    }

    public void AddShift(Shift shift)
    {
        _context.Shifts.Add(shift);
        _context.SaveChanges();
    }

}