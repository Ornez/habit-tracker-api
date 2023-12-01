namespace habit_tracker_api.Habits.DTOs;

public record CreateTimePeriodDto
{
    public int HabitId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}
