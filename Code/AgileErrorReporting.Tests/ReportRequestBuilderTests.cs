using System;
using Moq;
using NUnit.Framework;

namespace AgileErrorReporting.Tests
{
    [TestFixture]
    public class ReportRequestBuilderTests
    {
        const string SERIALIZER_OUTPUT = "serializer output";

        private Mock<IServiceProvider> _mockServiceProvider;
        private Mock<IErrorReportSerializer> _mockSerializer;
        private ReportRequestBuilder _subject;

        [SetUp]
        public void SetUp()
        {
            GlobalConfig.Settings.ServiceEndPoint = "http://global-endpoint.com";
            
            _mockSerializer = new Mock<IErrorReportSerializer>();
            _mockServiceProvider = new Mock<IServiceProvider>();
            GlobalConfig.ServiceProvider = _mockServiceProvider.Object;
            _mockServiceProvider.Setup(m => m.GetService(typeof (IErrorReportSerializer)))
                                .Returns(_mockSerializer.Object);

            _mockSerializer.Setup(m => m.Serialize(It.IsAny<ErrorReport>()))
                           .Returns(SERIALIZER_OUTPUT);

            _subject = new ReportRequestBuilder();
        }

        [TearDown]
        public void TearDown()
        {   
            if (AgileReporter.Instance != null)
            {
                AgileReporter.Instance.Dispose();
            }

            GlobalConfig.Settings.InstanceIdentifier = "user-token";
            GlobalConfig.Settings.AppName = "appName";
            GlobalConfig.Settings.ServiceEndPoint = "http://endpoint.com";
        }

        [Test]
        public void Build_Always_SetsUriToEndPoint()
        {
            GlobalConfig.Settings.ServiceEndPoint = "http://endpoint.com";

            var result = _subject.Build(new ErrorReport());
            result.Abort();
            
            Assert.AreEqual("http://endpoint.com", result.RequestUri.OriginalString);
        }

        [Test]
        public void Build_Always_SetsMethodToPost()
        {
            var result = _subject.Build(new ErrorReport());
            result.Abort();
            
            Assert.AreEqual("POST", result.Method);
        }

        [Test]
        public void Build_Always_SetsApiKeyInHeaders()
        {
            GlobalConfig.Settings.InstanceIdentifier = "user-token";

            var result = _subject.Build(new ErrorReport());
            result.Abort();
            
            Assert.AreEqual(GlobalConfig.Settings.InstanceIdentifier, result.Headers["apiKey"]);
        }

        [Test]
        public void Build_Always_SetsUserAgentToAppName()
        {
            GlobalConfig.Settings.AppName = "appName";

            var result = _subject.Build(new ErrorReport());

            Assert.AreEqual(GlobalConfig.Settings.AppName, result.UserAgent);
        }

        [Test]
        public void Build_Always_CallsSerializerSerialize()
        {
            var result = _subject.Build(new ErrorReport());
            result.Abort();
            
            _mockSerializer.Verify(m => m.Serialize(It.IsAny<ErrorReport>()));
        }

        [Test]
        public void Build_Always_SetsContentLength()
        {
            var result = _subject.Build(new ErrorReport());
            result.Abort();

            Assert.AreEqual(SERIALIZER_OUTPUT.Length, result.ContentLength);
        }
    }
}
