using System.Net;

namespace AgileErrorReporting
{
    public interface IReportRequestBuilder
    {
        HttpWebRequest Build(ErrorReport report);
    }
}