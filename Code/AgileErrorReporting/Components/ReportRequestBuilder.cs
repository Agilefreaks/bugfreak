using System.IO;
using System.Net;
using AgileErrorReporting.Utils;

namespace AgileErrorReporting.Components
{
    public class ReportRequestBuilder : IReportRequestBuilder
    {
        public const string InstanceIdentifierKey = "apiKey";
        public const string HttpMethod = "POST";

        public WebRequest Build(ErrorReport report)
        {
            var request = CreateRequest();
            SetMethod(request);
            Sign(request);
            SetAgent(request);
            Write(report, request);

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

        private void Write(ErrorReport report, HttpWebRequest request)
        {
            var serializer = GlobalConfig.ServiceProvider.GetService<IErrorReportSerializer>();

            var serializedObj = serializer.Serialize(report);

            using (var outputStream = request.GetRequestStream())
            {
                using (var writer = new StreamWriter(outputStream))
                {
                    writer.Write(serializedObj);
                    writer.Flush();
                    writer.Close();
                }

                outputStream.Flush();
                outputStream.Close();
            }
        }
    }
}