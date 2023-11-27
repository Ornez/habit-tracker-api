using Microsoft.AspNetCore.Identity;

namespace habit_tracker_api.Accounts.Entities;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser User { get; set; }
    public AppRole Role { get; set; }
}
