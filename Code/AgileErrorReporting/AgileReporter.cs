using System;
using AgileErrorReporting.Utils;

namespace AgileErrorReporting
{
    public class AgileReporter : IReportingService
    {
        private static AgileReporter _instance;
        private readonly IErrorReportQueue _errorReportQueue;

        public static IReportingService Instance
        {
            get
            {
                return _instance ?? (_instance = new AgileReporter());
            }
        }

        private AgileReporter()
        {
            if (string.IsNullOrEmpty(GlobalConfig.Settings.InstanceIdentifier))
            {
                throw new ArgumentException("Instance identifier not set");
            }
            if (string.IsNullOrEmpty(GlobalConfig.Settings.AppName))
            {
                throw new ArgumentException("AppName not set");
            }

            _errorReportQueue = GlobalConfig.ServiceProvider.GetService<IErrorReportQueue>();
        }

        public void BeginReport(Exception exc)
        {
            var errorReport = CreateReport(exc);
            Queue(errorReport);
        }

        private ErrorReport CreateReport(Exception exc)
        {
            return ErrorReport.FromException(exc);
        }

        private void Queue(ErrorReport errorReport)
        {
            _errorReportQueue.Enqueue(errorReport);
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}