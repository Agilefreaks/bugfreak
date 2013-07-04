using System;
using System.ComponentModel.Design;

namespace AgileErrorReporting
{
    public class GlobalConfig
    {
        public class Settings
        {
            public static string ServiceEndPoint { get; set; }

            public static string AppName { get; set; }

            public static string InstanceIdentifier { get; set; }
        }

        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider
        {
            get { return _serviceProvider ?? (_serviceProvider = GetDefaultContainer()); }
            set { _serviceProvider = value; }
        }

        private static IServiceContainer GetDefaultContainer()
        {
            var serviceContainer = new ServiceContainer();

            serviceContainer.AddService(typeof(IReportRequestBuilder), (container, type) => new ReportRequestBuilder());

            return serviceContainer;
        }
    }
}
