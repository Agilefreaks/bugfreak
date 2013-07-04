using System;
using Moq;
using NUnit.Framework;

namespace AgileErrorReporting.Tests
{
    [TestFixture]
    public class AgileReporterTests
    {
        private Mock<IReportRequestBuilder> _mockReportRequestFactory;
        private Mock<IServiceProvider> _mockServiceProvider;

        [SetUp]
        public void SetUp()
        {
            GlobalConfig.Settings.InstanceIdentifier = "user-token";
            GlobalConfig.Settings.AppName = "appName";

            _mockReportRequestFactory = new Mock<IReportRequestBuilder>();
            _mockServiceProvider = new Mock<IServiceProvider>();
            _mockServiceProvider.Setup(m => m.GetService(typeof (IReportRequestBuilder)))
                                .Returns(_mockReportRequestFactory.Object);

            GlobalConfig.ServiceProvider = _mockServiceProvider.Object;
        }

        [TearDown]
        public void TearDown()
        {
            GlobalConfig.Settings.InstanceIdentifier = "user-token";
            GlobalConfig.Settings.AppName = "appName";
            AgileReporter.Instance.Dispose();

            GlobalConfig.ServiceProvider = null;
        }

        [Test]
        public void Instance_Always_ReturnsNotNull()
        {
            var instance = AgileReporter.Instance;

            Assert.IsNotNull(instance);
        }

        [Test]
        public void Instance_Always_ReturnsSameInstance()
        {
            var instance1 = AgileReporter.Instance;
            var instance2 = AgileReporter.Instance;

            Assert.AreSame(instance1, instance2);
        }

        [Test]
        public void Instance_AfterCallingDisposeOnCurrentInstance_ReturnsNewInstance()
        {
            var instance1 = AgileReporter.Instance;
            instance1.Dispose();

            var instance2 = AgileReporter.Instance;

            Assert.AreNotSame(instance1, instance2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Instance_WhenApiKeyIsNotSet_RaisesArgumentException()
        {
            GlobalConfig.Settings.InstanceIdentifier = null;

            var instance1 = AgileReporter.Instance;
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Instance_WhenAppNameIsNotSet_RaisesArgumentException()
        {
            GlobalConfig.Settings.InstanceIdentifier = "user-token";
            GlobalConfig.Settings.AppName = null;

            var instance = AgileReporter.Instance;
        }

        [Test]
        public void BeginRequest_Always_CallsReportFactoryCreate()
        {
            AgileReporter.Instance.BeginReport(new Exception());

            _mockServiceProvider.Verify(m => m.GetService(typeof(IReportRequestBuilder)));
        }
    }
}
