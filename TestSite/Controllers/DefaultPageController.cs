using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using TestSite.Models.Pages;
using TestSite.RestMessages;
using TestSite.Services.InstaEdge;

namespace TestSite.Controllers
{
    public class DefaultPageController : PageController<DefaultPage>
    {
        public async Task<ActionResult> Index(DefaultPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var service = new InstaEdgeDataService(new RestCommunicator());
            var endpoint = "https://elxau-api.atosicloud.net/instaedgedt-mgmt-ws/apis/technician/1.0/technicianAvailability";
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
            var response = await service.GetTechnicianAvailibility(endpoint, request, headers);

            return View(currentPage);
        }
    }
}