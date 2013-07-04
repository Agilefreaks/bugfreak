using NUnit.Framework;

namespace AgileErrorReporting.Tests
{
    [TestFixture]
    public class GlobalConfigTests
    {
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
    }
}
