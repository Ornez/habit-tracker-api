using habit_tracker_api.Accounts.Entities;
using habit_tracker_api.Habits.DTOs;
using habit_tracker_api.Habits.Entities;
using habit_tracker_api.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace habit_tracker_api.Habits.Repositories;

public class HabitRepository : IHabitRepository
{
    private readonly DataContext _context;

    public HabitRepository(DataContext context)
    {
        _context = context;
    }

    public void AddHabit(Habit habit)
    {
        _context.Habits.Add(habit);
    }

    public async Task<Habit> GetHabit(int id)
    {
        return await _context.Habits.FindAsync(id);
    }

    public async Task<Habit> GetHabit(string name, AppUser appUser)
    {
        return await _context.Habits.Where(habit => habit.AppUser == appUser).Include(habit => habit.Occurrences).FirstAsync(habit => habit.Name == name);
    }

    public async Task<List<HabitDto>> GetHabitsForUser(AppUser appUser)
    {
        var habits = await _context.Habits
            .Where(habit => habit.AppUser == appUser)
            .Include(habit => habit.Occurrences)
            .ToListAsync();

        List<HabitDto> habitDtos = new();
        foreach (var habit in habits)
        {
            List<TimePeriodDto> occurrenceDtos = new();
            foreach (var occurrence in habit.Occurrences)
            {
                occurrenceDtos.Add(new TimePeriodDto()
                {
                    HabitId = occurrence.HabitId,
                    Start = occurrence.Start,
                    End = occurrence.End
                });
            }

            HabitDto habitDto = new()
            {
                Id = habit.Id,
                Name = habit.Name,
                Category = habit.Category,
                Hours = habit.Hours,
                Minutes = habit.Minutes,
                Frequency = habit.Frequency,
                Occurrences = occurrenceDtos
            };
            habitDtos.Add(habitDto);
        }
        return habitDtos;
    }

    public void UpdateHabit(Habit habit)
    {
        _context.Entry(habit).State = EntityState.Modified;
    }

    public void DeleteHabit(Habit habit)
    {
        _context.Habits.Remove(habit);
    }
}
