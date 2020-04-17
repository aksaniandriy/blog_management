using System;
using System.Net;

namespace Blog.Common.Exceptions
{
    public class BlogException : Exception
    {
        public BlogException()
        {
        }

        public BlogException(string message)
            : base(message)
        {
        }

        public BlogException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BlogException(HttpStatusCode httpReturnCode, string message)
            : base(message)
        {
            this.HttpReturnCode = httpReturnCode;
        }

        public HttpStatusCode HttpReturnCode { get; }
    }
}
