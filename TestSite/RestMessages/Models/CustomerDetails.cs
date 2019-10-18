using System;

namespace TestSite.RestMessages
{
    public class CustomerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long MobileNo { get; set; }
        public string AlternateMobile { get; set; }
        public string EmailAddress { get; set; }
        public string AlternateEmailAddress { get; set; }
        public long SourcePartyCustomerId { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public long Branch { get; set; }
        public long PostalCode { get; set; }
        public string Country { get; set; }
        public string CustomerCode { get; set; }
        public string ResidentialTelephoneNo { get; set; }
        public string OfficeTelephoneNo { get; set; }
        public string OfficeExtensionNo { get; set; }
        public DateTimeOffset CustRegistrationDateTime { get; set; }
        public string AddContactDetail { get; set; }
        public string Remarks { get; set; }
        public string FaxNo { get; set; }
        public long UnitNo { get; set; }
        public string Optin { get; set; }
        public string DataProtectionConsent { get; set; }
        public string OptinVoice { get; set; }
        public string OptinSmsMms { get; set; }
        public string OptinFax { get; set; }
        public string OptinEmail { get; set; }
        public string OptinAnyOther { get; set; }
        public string TermsAndConditionsAcceptance { get; set; }
    }




}