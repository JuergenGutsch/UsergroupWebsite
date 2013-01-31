using NUnit.Framework;
using XmlRepository.DataProviders;

namespace CommunitySite.Tests
{
    [TestFixture]
    public class SpeakerRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            XmlRepository.XmlRepository.DefaultQueryProperty = "Id";
            XmlRepository.XmlRepository.DataProvider = new XmlFileProvider(@"C:\Git\UsergroupWebsite\CommunitySite.Web\App_Data");
        }

        [Test]
        public void ContructorTest()
        {

        }

    }
}