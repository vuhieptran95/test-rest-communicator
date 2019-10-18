using System;

namespace TestSite.RestMessages
{
    public class ServiceOrderDetails
    {
        public string ServiceOrderLocation { get; set; }
        public string CallType { get; set; }
        public long RepairType { get; set; }
        public string CallersName { get; set; }
        public string CustomerOrderRefNo { get; set; }
        public string FaultDescription { get; set; }
        public long SourcePartyTicketId { get; set; }
        public string ServiceOrderNumber { get; set; }
        public long ServiceOrderRcptMode { get; set; }
        public string ActionTaken { get; set; }
        public string CallRecdBy { get; set; }
        public string CallRemarks { get; set; }
        public string AirId { get; set; }
        public string AirStatus { get; set; }
        public string RbcNumber { get; set; }
        public string AuthorizationNo { get; set; }
        public string SoStatus { get; set; }
        public string SoRemarks { get; set; }
        public DateTimeOffset SoRegistrationDateTime { get; set; }
        public string SoCloseDateTime { get; set; }
        public string AssistServiceOrderNumber { get; set; }
        public string IsReversed { get; set; }
        public string IsReopened { get; set; }
        public string CancelReasonCode { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string TechnicianCode { get; set; }
    }




}