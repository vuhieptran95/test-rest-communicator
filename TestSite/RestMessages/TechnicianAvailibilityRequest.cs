using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSite.RestMessages
{
    public class TechnicianAvailibilityRequest : RestRequest
    {
        public string Source { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string BranchCode { get; set; }
        public string ServiceProductLine { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
    }
}