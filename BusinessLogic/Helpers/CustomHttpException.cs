using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{

    [Serializable]
    public class CustomHttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public CustomHttpException() { }
        public CustomHttpException(string message, HttpStatusCode statusCode) : base(message) {
            StatusCode = statusCode;
        }
        public CustomHttpException(string message, Exception inner, HttpStatusCode statusCode) : base(message, inner) {
            StatusCode = statusCode;
        }
        protected CustomHttpException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
