using NUnit.Framework;

namespace AgileErrorReporting.Tests
{
    [TestFixture]
    public class ReportRequestBuilderTests
    {
        private ReportRequestBuilder _subject;

        [SetUp]
        public void SetUp()
        {
            GlobalConfig.Settings.ServiceEndPoint = "http://global-endpoint.com";
            _subject = new ReportRequestBuilder();
        }

        [Test]
        public void Build_Always_SetsUriToEndPoint()
        {
            GlobalConfig.Settings.ServiceEndPoint = "http://endpoint.com";

            var result = _subject.Build();

            Assert.AreEqual("http://endpoint.com", result.RequestUri.OriginalString);
        }

        [Test]
        public void Build_Always_SetsMethodToPost()
        {
            var result = _subject.Build();

            Assert.AreEqual("POST", result.Method);
        }

        [Test]
        public void Build_Always_SetsApiKeyInHeaders()
        {
            GlobalConfig.Settings.InstanceIdentifier = "user-token";

            var result = _subject.Build();

            Assert.AreEqual(GlobalConfig.Settings.InstanceIdentifier, result.Headers["apiKey"]);
        }

        [Test]
        public void Build_Always_SetsUserAgentToAppName()
        {
            GlobalConfig.Settings.AppName = "appName";

            var result = _subject.Build();

            Assert.AreEqual(GlobalConfig.Settings.AppName, result.UserAgent);
        }
    }
}
