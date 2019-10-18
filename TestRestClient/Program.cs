using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSite.RestMessages;
using TestSite.Services.InstaEdge;

namespace TestRestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new InstaEdgeDataService(new RestCommunicator());
            var endpoint = "https://elxau-api.atosicloud.net/instaedgedt-mgmt-ws/apis/technician/1.0/technicianAvailabilit";
            var request = new TechnicianAvailibilityRequest
            {
                Source = "customer",
                Suburb = "MASCOT",
                State = "NSW",
                PostalCode = "2020",
                BranchCode = "2294",
                ServiceProductLine = "EWF",
                AppointmentDate = "2019-10-18",
                AppointmentTime = "AD"
            };
            var headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("apikey", "46f7-6db8-50ebcd876472"),
                new KeyValuePair<string, string>("countryheader", "AUS"),
                new KeyValuePair<string, string>("Content-Type", "application/json")
            };
            var response = service.GetTechnicianAvailibility(endpoint, request, headers).GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}
