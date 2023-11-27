using habit_tracker_api.Accounts.Entities;

namespace habit_tracker_api.Habits.Entities;

public class Habit
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Per { get; set; }

}
