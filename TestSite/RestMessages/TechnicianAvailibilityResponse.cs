using System.Collections.Generic;

namespace TestSite.RestMessages
{

    public abstract class RestRequest
    {

    }

    public interface IExpectedArrayResponse
    {

    }

    public class TechnicianAvailibilityResponse : RestResponse, IExpectedArrayResponse
    {
        public string Status { get; set; }
        public object Description { get; set; }
        public object ErrorCode { get; set; }
        public IEnumerable<Technician> Technicians { get; set; }

    }

    public class Technician
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string W1 { get; set; }
        public string W2 { get; set; }
        public string Ad { get; set; }
    }



}