using System.Net;

namespace AgileErrorReporting
{
    public class ReportRequestBuilder : IReportRequestBuilder
    {
        public const string InstanceIdentifierKey = "apiKey";
        public const string HttpMethod = "POST";

        public HttpWebRequest Build()
        {
            var request = CreateRequest();
            SetMethod(request);
            Sign(request);
            SetAgent(request);

            return request;
        }

        private HttpWebRequest CreateRequest()
        {
            return (HttpWebRequest) WebRequest.Create(GlobalConfig.Settings.ServiceEndPoint);
        }

        private void SetMethod(HttpWebRequest request)
        {
            request.Method = HttpMethod;
        }

        private void Sign(HttpWebRequest request)
        {
            request.Headers.Add(InstanceIdentifierKey, GlobalConfig.Settings.InstanceIdentifier);
        }

        private void SetAgent(HttpWebRequest request)
        {
            request.UserAgent = GlobalConfig.Settings.AppName;
        }
    }
}