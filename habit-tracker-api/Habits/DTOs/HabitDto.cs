namespace habit_tracker_api.Habits.DTOs;

public record HabitDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required int Hours { get; set; }
    public required int Minutes { get; set; }
    public required string Frequency { get; set; }
    public required List<TimePeriodDto> Occurrences { get; set; }
}
