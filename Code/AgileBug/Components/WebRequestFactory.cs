using System;
using System.Net;

namespace AgileBug.Components
{
    public class WebRequestFactory : IWebRequestCreate
    {
        public WebRequest Create(Uri uri)
        {
            return WebRequest.Create(uri);
        }
    }
}