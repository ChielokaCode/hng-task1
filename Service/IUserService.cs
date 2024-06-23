namespace hng_task1.Service
{
    public interface IUserService
    {
        User CreateUser(string visitor_name, string clientIp);
    }
}