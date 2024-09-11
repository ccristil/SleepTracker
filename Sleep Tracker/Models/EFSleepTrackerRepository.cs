using Microsoft.EntityFrameworkCore;

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
    public IQueryable<DiaperChange> DiaperChanges => _context.DiaperChanges;

    public void AddNight(Night night)
    {
        _context.Nights.Add(night);
        _context.SaveChanges();
    }

    public void AddShift(Shift shift)
    {
        _context.Shifts.Add(shift);
        
        _context.SaveChanges();

        UpdateTotalHoursSlept(shift.NightId);
    }

    public void AddDiaperChange(DiaperChange diaperChange)
    {
        _context.DiaperChanges.Add(diaperChange);
        _context.SaveChanges();
        
    }

    public void EditShift(Shift shift)
    {
        _context.Shifts.Update(shift);
        _context.SaveChanges();
        
        UpdateTotalHoursSlept(shift.NightId);

    }

    public void UpdateTotalHoursSlept(int nightId)
    {
        var night = _context.Nights
            .FirstOrDefault(n => n.NightId == nightId);

        var shifts = _context.Shifts
            .Where(x => x.NightId == nightId);

        var sumHoursSlept = shifts.Sum(x => x.BabyHours);

        if (night.TotalBabyHours != sumHoursSlept)
        {
            night.TotalBabyHours = sumHoursSlept;
            _context.SaveChanges();
        }
    }

}