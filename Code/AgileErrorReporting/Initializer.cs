using System;
using System.ComponentModel.Design;

namespace AgileErrorReporting
{
    internal class Initializer
    {
        public static void Initialize()
        {
            VerifySettings();
            InitServices();
            InitReporter();
        }

        private static void VerifySettings()
        {
            if (String.IsNullOrEmpty(GlobalConfig.Settings.InstanceIdentifier))
            {
                throw new ArgumentException("Instance identifier not set");
            }
            if (String.IsNullOrEmpty(GlobalConfig.Settings.AppName))
            {
                throw new ArgumentException("AppName not set");
            }
        }

        private static void InitServices()
        {
            var serviceContainer = new ServiceContainer();

            RegisterComponents(serviceContainer);

            GlobalConfig.ServiceProvider = serviceContainer;
        }

        private static void RegisterComponents(ServiceContainer serviceContainer)
        {
            serviceContainer.AddService(typeof(IReportRequestBuilder), (container, type) => new ReportRequestBuilder());
            serviceContainer.AddService(typeof(IErrorReportQueue), new ErrorReportQueue());
        }

        private static void InitReporter()
        {
            AgileReporter.Instance = new AgileReporter();
        }
    }
}
