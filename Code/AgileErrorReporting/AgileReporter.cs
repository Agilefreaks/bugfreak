using System;

namespace AgileErrorReporting
{
    public class AgileReporter : IReportingService
    {
        private static AgileReporter _instance;
        public static IReportingService Instance
        {
            get
            {
                return _instance ?? (_instance = new AgileReporter());
            }
        }

        private AgileReporter()
        {
            if (string.IsNullOrEmpty(Settings.InstanceIdentifier))
            {
                throw new ArgumentException("Instance identifier not set");
            }
            if (string.IsNullOrEmpty(Settings.AppName))
            {
                throw new ArgumentException("AppName not set");
            }
        }

        public void BeginReport(Exception exc)
        {
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}