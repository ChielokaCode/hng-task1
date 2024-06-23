namespace hng_task1.ServiceImpl
{
    public class IpService : IIpService
    {
        public string GetClientIp(HttpContext httpContext)
        {
            // Use null-conditional operator to safely access RemoteIpAddress
            var remoteIpAddress = httpContext?.Connection?.RemoteIpAddress;

            // Check if RemoteIpAddress is null and provide a default value if necessary
            return remoteIpAddress?.ToString() ?? "IP not available";
        }
    }
}