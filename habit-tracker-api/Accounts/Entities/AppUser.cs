using habit_tracker_api.Habits.Entities;
using Microsoft.AspNetCore.Identity;

namespace habit_tracker_api.Accounts.Entities;

public class AppUser : IdentityUser<int>
{
    public List<Habit> Habits { get; set; } = new();

    public ICollection<AppUserRole> UserRoles { get; set; }
}
