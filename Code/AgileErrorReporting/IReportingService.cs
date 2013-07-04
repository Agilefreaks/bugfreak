using System;

namespace AgileErrorReporting
{
    public interface IReportingService : IDisposable
    {
        void BeginReport(Exception exc);
    }
}