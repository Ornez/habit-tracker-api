using Microsoft.AspNetCore.Identity;

namespace habit_tracker_api.Accounts.Entities;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}
