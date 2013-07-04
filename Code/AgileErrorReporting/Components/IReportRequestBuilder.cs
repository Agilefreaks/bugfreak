using System.Net;

namespace AgileErrorReporting.Components
{
    public interface IReportRequestBuilder
    {
        HttpWebRequest Build(ErrorReport report);
    }
}