using System;
using System.Net;

namespace PIMS.API.Infrastructure.Errors
{
    public class RestException : Exception
    {
        public Object Errors { get; set; }

        public HttpStatusCode Code { get; set; }

        public RestException(HttpStatusCode code, Object errors = null)
        {
            Code = code;
            Errors = errors;
        }
    }
}
