using habit_tracker_api.Accounts.Entities;

namespace habit_tracker_api.Habits.Entities;

public class Habit
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public string Frequency { get; set; }
    public List<TimePeriod> Occurrences { get; set; } = new();
}
