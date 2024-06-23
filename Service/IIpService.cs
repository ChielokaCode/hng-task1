namespace hng_task1.Service
{
    public interface IIpService
    {
        string GetClientIp(HttpContext httpContext);
    }
}