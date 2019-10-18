namespace TestCustomControllers.Models
{
    public class DataTransferObjects
    {
    }

    public class Rootobject
    {
        public string source { get; set; }
        public string suburb { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string branchCode { get; set; }
        public string serviceProductLine { get; set; }
        public string appointmentDate { get; set; }
        public string appointmentTime { get; set; }
    }

    public interface IInstaEdgeDataService
    {
        object CreateCustomer(object customerDto);

    }

    public class InstaEdgeDataService : IInstaEdgeDataService
    {
        IRestCommunicator _restCommunicator;
        public InstaEdgeDataService(IRestCommunicator restCommunicator)
        {

        }
        public object CreateCustomer(object customerDto)
        {
            throw new System.NotImplementedException();
        }
    }

    //[ServiceConfiguration()]
    public interface IRestCommunicator
    {
        object Post(string url, object data, string header);
    }
}