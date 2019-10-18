using System.Collections;
using System.Collections.Generic;

namespace TestSite.RestMessages
{
    public class ErrorResponse : BusinessError
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string ErrorCode { get; set; }
    }

    public class BusinessError
    {

    }

    public class UnifiedResponse
    {
        public IEnumerable<RestResponse> Responses { get; set; }
        public IEnumerable<BusinessError> Errors { get; set; }
    }
}