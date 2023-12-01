using habit_tracker_api.Accounts.Entities;
using habit_tracker_api.Habits.DTOs;
using habit_tracker_api.Habits.Entities;

namespace habit_tracker_api.Habits.Repositories;

public interface IHabitRepository
{
    void AddHabit(Habit habit);
    Task<Habit> GetHabit(int id);
    Task<Habit> GetHabit(string name, AppUser appUser);
    Task<List<HabitDto>> GetHabitsForUser(AppUser appUser);
    void UpdateHabit(Habit habit);
    void DeleteHabit(Habit habit);
}
