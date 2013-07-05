using System.Net;

namespace AgileBug.Components
{
    public interface IReportRequestBuilder
    {
        WebRequest Build(ErrorReport report);
    }
}