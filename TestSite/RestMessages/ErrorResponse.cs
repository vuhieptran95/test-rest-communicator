using System.Collections;
using System.Collections.Generic;

namespace TestSite.RestMessages
{
    public class ErrorResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}