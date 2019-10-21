using System;

namespace TestSite.RestMessages
{
    public class UnifiedResponse<T, Error> where T: RestResponse where Error: ErrorResponse
    {
        public T Response { get; set; }
        public Error BusinessError { get; set; }
        public Exception Exception { get; set; }
    }
}