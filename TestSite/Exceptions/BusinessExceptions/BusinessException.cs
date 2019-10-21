using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestSite.RestMessages;

namespace TestSite.Exceptions.BusinessExceptions
{
    public class BusinessException<E> : Exception where E: ErrorResponse
    {
        public BusinessException(string message = "Business exception") : base(message)
        {

        }
        public E BusinessError { get; set; }
    }
}