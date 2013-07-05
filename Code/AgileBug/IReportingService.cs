using System;

namespace AgileBug
{
    public interface IReportingService
    {
        void BeginReport(Exception exc);
    }
}