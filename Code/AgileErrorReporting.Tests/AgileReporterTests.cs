using System;
using AgileErrorReporting.Components;
using Moq;
using NUnit.Framework;

namespace AgileErrorReporting.Tests
{
    [TestFixture]
    public class AgileReporterTests
    {
        private Mock<IErrorReportQueue> _mockErrorQueue;
        private Mock<IServiceProvider> _mockServiceProvider;

        [SetUp]
        public void SetUp()
        {
            GlobalConfig.Settings.InstanceIdentifier = "user-token";
            GlobalConfig.Settings.AppName = "appName";

            AgileReporter.Init();

            _mockErrorQueue = new Mock<IErrorReportQueue>();
            _mockServiceProvider = new Mock<IServiceProvider>();
            _mockServiceProvider.Setup(m => m.GetService(typeof(IErrorReportQueue)))
                                .Returns(_mockErrorQueue.Object);

            GlobalConfig.ServiceProvider = _mockServiceProvider.Object;
        }

        [TearDown]
        public void TearDown()
        {
            if (AgileReporter.Instance != null)
            {
                AgileReporter.Dispose();
            }

            GlobalConfig.ServiceProvider = null;
            GlobalConfig.Settings.InstanceIdentifier = null;
            GlobalConfig.Settings.AppName = null;
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
        public void Instance_AfterCallingDisposeOnCurrentInstance_ReturnsNull()
        {
            AgileReporter.Dispose();

            var instance = AgileReporter.Instance;

            Assert.IsNull(instance);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Init_WhenApiKeyIsNotSet_RaisesArgumentException()
        {
            GlobalConfig.Settings.InstanceIdentifier = null;

            AgileReporter.Init();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Init_WhenAppNameIsNotSet_RaisesArgumentException()
        {
            GlobalConfig.Settings.InstanceIdentifier = "user-token";
            GlobalConfig.Settings.AppName = null;

            AgileReporter.Init();
        }

        [Test]
        public void Init_Always_SetsSerializerToFormSerializer()
        {
            GlobalConfig.Settings.InstanceIdentifier = "user-token";
            GlobalConfig.Settings.AppName = "app";

            AgileReporter.Init();

            Assert.IsTrue(GlobalConfig.ErrorReportSerializer is FormErrorReportSerializer);
        }

        [Test]
        public void BeginRequest_Always_CallsReportQueueEnqueue()
        {
            AgileReporter.Instance.BeginReport(new Exception());

            _mockErrorQueue.Verify(m => m.Enqueue(It.IsAny<ErrorReport>()));
        }
    }
}
