using habit_tracker_api.Accounts.Repositories;
using habit_tracker_api.Habits.Repositories;

namespace habit_tracker_api.Shared.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public IUserRepository UserRepository => new UserRepository(_context);
    public IHabitRepository HabitRepository => new HabitRepository(_context);

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}
