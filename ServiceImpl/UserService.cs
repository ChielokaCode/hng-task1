namespace hng_task1.ServiceImpl
{
    public class UserService : IUserService
    {
        public User CreateUser(string visitor_name, string clientIp)
        {
            return new User
            {
                Client_ip = clientIp,
                Greeting = string.IsNullOrEmpty(visitor_name) ? "Unknown Person" : $"Hello {visitor_name}!",
            };
        }
    }
}