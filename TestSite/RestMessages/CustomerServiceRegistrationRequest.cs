namespace TestSite.RestMessages
{
    public class CustomerServiceRegistrationRequest
    {
        public string Source { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public ServiceOrderDetails ServiceOrderDetails { get; set; }
    }




}