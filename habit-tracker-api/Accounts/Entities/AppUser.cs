using Microsoft.AspNetCore.Identity;

namespace habit_tracker_api.Accounts.Entities;

public class AppUser : IdentityUser<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}
