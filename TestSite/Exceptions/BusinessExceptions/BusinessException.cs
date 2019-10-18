using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSite.RestMessages;

namespace TestSite.Exceptions.BusinessExceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message = "Business exception") : base(message)
        {

        }
        public IEnumerable<BusinessError> BusinessErrors { get; set; }
    }
}