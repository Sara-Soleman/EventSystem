using Microsoft.AspNetCore.Identity;

namespace Event_System.Core.Entity.UserModel
{
    public class User :   IdentityUser
    {
        public string Full_Name { get; set; } = "";
    }
}
