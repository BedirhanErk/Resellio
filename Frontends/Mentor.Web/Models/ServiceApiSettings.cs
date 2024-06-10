namespace Resellio.Web.Models
{
    public class ServiceApiSettings
    {
        public string GatewayUri { get; set; }
        public string IdentityUri { get; set; }
        public string PhotoStockUri { get; set; }
        public ServiceApi Catalog { get; set; }
        public ServiceApi PhotoStock { get; set; }
        public ServiceApi Basket { get; set; }
        public ServiceApi Discount { get; set; }
        public ServiceApi Order { get; set; }
        public ServiceApi Payment { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
