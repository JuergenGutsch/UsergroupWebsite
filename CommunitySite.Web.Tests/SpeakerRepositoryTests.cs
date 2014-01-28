using CommunitySite.Web.Data.Models;
using Gos.SimpleObjectStore;
using NUnit.Framework;

namespace CommunitySite.Tests
{
    [TestFixture]
    public class SpeakerRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            using (var repository = ObjectStore.GetInstance<Event>())
            {

            }
        }

        [Test]
        public void ContructorTest()
        {

        }

    }
}