using System.ComponentModel.DataAnnotations.Schema;

namespace habit_tracker_api.Habits.Entities;

[Table("Occurrences")]
public class TimePeriod
{
    public int Id { get; set; }
    public int HabitId { get; set; }
    public Habit Habit { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}
