using System;
using AgileErrorReporting.Utils;

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

        private readonly IReportRequestBuilder _reportRequestBuilder;
        
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

            _reportRequestBuilder = GlobalConfig.ServiceProvider.GetService<IReportRequestBuilder>();
        }

        public void BeginReport(Exception exc)
        {
            var request = _reportRequestBuilder.Build();
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}