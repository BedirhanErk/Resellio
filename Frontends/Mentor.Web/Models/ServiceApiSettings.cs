namespace Mentor.Web.Models
{
    public class ServiceApiSettings
    {
        public string GatewayUri { get; set; }
        public string IdentityUri { get; set; }
        public string PhotoStockUri { get; set; }
        public ServiceApi Catalog { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
