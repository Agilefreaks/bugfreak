using NUnit.Framework;

namespace AgileErrorReporting.Tests
{
    [TestFixture]
    public class GlobalConfigTests
    {
        [SetUp]
        public void SetUp()
        {
            GlobalConfig.Settings.AppName = "app";
            GlobalConfig.Settings.InstanceIdentifier = "v2.2";
            
            AgileReporter.Init();
        }

        [TearDown]
        public void TearDown()
        {
            GlobalConfig.Settings.AppName = null;
            GlobalConfig.Settings.InstanceIdentifier = null;
        }

        [Test]
        public void ServiceProviderGet_Always_ReturnsInstance()
        {
            var result = GlobalConfig.ServiceProvider;

            Assert.IsNotNull(result);
        }

        [Test]
        public void ServiceProvider_GetServiceOfTypeIReportRequestBuilder_ReturnsInstanceOfReportRequestBuilder()
        {
            var result = GlobalConfig.ServiceProvider.GetService(typeof (IReportRequestBuilder));

            Assert.AreEqual(typeof(ReportRequestBuilder), result.GetType());
        }

        [Test]
        public void ServiceProvider_GetServiceOfTypeIErrorReportQueue_ReturnsInstance()
        {
            var result = GlobalConfig.ServiceProvider.GetService(typeof (IErrorReportQueue));

            Assert.IsNotNull(result);
        }

        [Test]
        public void ServiceProvider_GetServiceOfTypeIErrorReportQueue_ReturnsSameInstance()
        {
            var instance1 = GlobalConfig.ServiceProvider.GetService(typeof (IErrorReportQueue));

            var instance2 = GlobalConfig.ServiceProvider.GetService(typeof (IErrorReportQueue));

            Assert.AreSame(instance1, instance2);
        }
    }
}
