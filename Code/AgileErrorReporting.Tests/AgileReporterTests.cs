using System;
using NUnit.Framework;

namespace AgileErrorReporting.Tests
{
    [TestFixture]
    public class AgileReporterTests
    {
        [SetUp]
        public void SetUp()
        {
            Settings.InstanceIdentifier = "user-token";
            Settings.AppName = "appName";
        }

        [TearDown]
        public void TearDown()
        {
            Settings.InstanceIdentifier = "user-token";
            Settings.AppName = "appName";
            AgileReporter.Instance.Dispose();
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
            Settings.InstanceIdentifier = null;

            var instance1 = AgileReporter.Instance;
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Instance_WhenAppNameIsNotSet_RaisesArgumentException()
        {
            Settings.InstanceIdentifier = "user-token";
            Settings.AppName = null;

            var instance = AgileReporter.Instance;
        }
    }
}
