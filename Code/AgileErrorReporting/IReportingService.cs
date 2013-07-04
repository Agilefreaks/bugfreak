using System;

namespace AgileErrorReporting
{
    public interface IReportingService
    {
        void BeginReport(Exception exc);
    }
}