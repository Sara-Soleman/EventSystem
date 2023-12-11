using Event_System.Core.Entity.UserModel;

namespace Event_System.Persistance.Interface
{
    public interface IJwtTokenAuth
    {
        public string GenerateEncodedToken(User user);
    }
}
