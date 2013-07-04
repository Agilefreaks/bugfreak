using System.Net;

namespace AgileErrorReporting.Components
{
    public interface IReportRequestBuilder
    {
        WebRequest Build(ErrorReport report);
    }
}