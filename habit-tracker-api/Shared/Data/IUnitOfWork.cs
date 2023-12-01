using habit_tracker_api.Accounts.Repositories;
using habit_tracker_api.Habits.Repositories;

namespace habit_tracker_api.Shared.Data;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IHabitRepository HabitRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}
