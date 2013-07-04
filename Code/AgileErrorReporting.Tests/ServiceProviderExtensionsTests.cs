using System;
using Moq;
using NUnit.Framework;
using AgileErrorReporting.Utils;

namespace AgileErrorReporting.Tests
{
    [TestFixture]
    public class ServiceProviderExtensionsTests
    {
        [Test]
        public void GetService_Always_ReturnsInstanceCastedToGenericType()
        {
            var mockServiceProvider = new Mock<IServiceProvider>();
            mockServiceProvider.Setup(m => m.GetService(typeof (IServiceProvider)))
                               .Returns(mockServiceProvider.Object);

            var result = mockServiceProvider.Object.GetService<IServiceProvider>();

            Assert.AreSame(mockServiceProvider.Object, result);
        }
    }
}
